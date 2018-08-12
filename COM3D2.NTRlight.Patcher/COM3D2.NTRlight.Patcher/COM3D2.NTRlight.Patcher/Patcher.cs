using Mono.Cecil;
using Mono.Cecil.Inject;
using System.Reflection;


namespace COM3D2.NTRlight.Patcher
{
    public static class Patcher
    {

        public static readonly string[] TargetAssemblyNames = { "Assembly-CSharp.dll" };


       public static MethodDefinition Enable_ntr = null;
       public static MethodDefinition Disable_ntr = null;

// simple patching method for setting one hook at start of the method and on at the end
       public static void Sethook(MethodDefinition target )
        {
            target.InjectWith(Enable_ntr);
            target.InjectWith(Disable_ntr, -1);


        }
  


        public static void Patch(AssemblyDefinition assembly)

        {
            AssemblyDefinition Hook_ass = AssemblyDefinition.ReadAssembly(Assembly.GetExecutingAssembly().Location);
            TypeDefinition Hooks = Hook_ass.MainModule.GetType("COM3D2.NTRlight.Patcher.Hooks");
            //get hook methods
            
             Enable_ntr = Hooks.GetMethod("Enable_ntr");
             Disable_ntr = Hooks.GetMethod("Disable_ntr");
         
          
         
           // now we get a bunch of methods that check for NTR lock and fiddle with them
           // fiddle with acquisition and display of skills and classes
            
           Sethook(assembly.MainModule.GetType("YotogiSkillSelectManager").GetMethod("Awake"));
         
            
           Sethook(assembly.MainModule.GetType("YotogiSkillListManager").GetMethod("CreateData"));
         
           
           Sethook(assembly.MainModule.GetType("YotogiResultManager").GetMethod("OnCall"));
         
           Sethook(assembly.MainModule.GetType("YotogiOldSkillSelectManager").GetMethod("Awake"));
         
            
           Sethook(assembly.MainModule.GetType("YotogiOldResultManager").GetMethod("OnCall"));
         
            
           Sethook(assembly.MainModule.GetType("YotogiClassListManager").GetMethod("CreateData"));
         
           // fiddle with facility availability
         
            
           Sethook(assembly.MainModule.GetType("SceneFacilityManagement").GetMethod("OpenFacilityInfoList"));
         
           
           Sethook(assembly.MainModule.GetType("SceneFacilityManagement").GetMethod("SetUpFacilityTypeList"));
         
         
           // fiddle with free mode
         
         
           
           Sethook( assembly.MainModule.GetType("FreeSkillSelect").GetMethod("CreateCategory"));
         
            
           Sethook( assembly.MainModule.GetType("FreeSkillSelectOld").GetMethod("CreateCategory"));


        }
    }
}
