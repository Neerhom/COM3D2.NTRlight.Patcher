using Mono.Cecil;
using Mono.Cecil.Inject;
using System.Reflection;


namespace COM3D2.NTRlight.Patcher
{
    public static class Patcher
    {

        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };

              

    
        // 0 target type, 1 target method
        private static string[,] targets = new string[,] {
           
           {"YotogiSkillSelectManager","Awake"},
           {"YotogiSkillListManager","CreateData"},
           {"YotogiResultManager","OnCall"},
           {"YotogiOldSkillSelectManager","Awake"},
           {"YotogiOldResultManager","OnCall"},
           {"YotogiClassListManager","CreateData"},
           {"SceneFacilityManagement","OpenFacilityInfoList"},
           {"SceneFacilityManagement","SetUpFacilityTypeList"},
           {"FreeSkillSelect","CreateCategory"},
           {"FreeSkillSelectOld","CreateCategory"}
        };

        public static void Patch(AssemblyDefinition assembly)

        {
            string Patcher_location = Assembly.GetExecutingAssembly().Location;
            AssemblyDefinition Hook_ass = AssemblyDefinition.ReadAssembly(Patcher_location);
            TypeDefinition Hooks = Hook_ass.MainModule.GetType("COM3D2.NTRlight.Patcher.Hooks");
            //get hook methods

           MethodDefinition  FakeLock = Hooks.GetMethod("FakeLock");
           MethodDefinition  Allow_faking = Hooks.GetMethod("Allow_faking");

            // patch faker into getter
            MethodDefinition get_lockNTRPlay = assembly.MainModule.GetType("PlayerStatus.Status").GetMethod("get_lockNTRPlay");
            get_lockNTRPlay.InjectWith(FakeLock, flags: InjectFlags.ModifyReturn);

            //patch targets to activate fake when they're initiated
            int length = targets.GetLength(0);
            for (int i = 0; i < length; i++)
            {

                assembly.MainModule.GetType(targets[i, 0]).GetMethod(targets[i, 1]).InjectWith(Allow_faking);

            }

          

            if (Patcher_location.Contains("lock_on"))
            {
                assembly.MainModule.GetType("DailyMgr").GetMethod("OpenPanel").InjectWith(Hooks.GetMethod("LockON"));

            }
            else if (Patcher_location.Contains("lock_off"))
            {

                assembly.MainModule.GetType("DailyMgr").GetMethod("OpenPanel").InjectWith(Hooks.GetMethod("LockOFF"));
            }
        }
    }
}
