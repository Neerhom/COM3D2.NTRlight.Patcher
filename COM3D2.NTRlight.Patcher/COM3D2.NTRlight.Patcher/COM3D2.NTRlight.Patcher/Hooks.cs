using System;

namespace COM3D2.NTRlight.Patcher
{
    public static class Hooks
    {

       static bool fakereturn = false;




        //  fakes return of getter for lockNTRPlay
        public static bool FakeLock( out bool result)

        {
            result = false;

            if (fakereturn)
            {
                fakereturn = false;
                return true;
            }
            else { return false; }
        }

        // the method is injected into a set of target method that call getter of lockNTRPlay (PlayerStatus.Status.get_lockNTRPlay())
        // this method allows changing of it's retrun
        public static void Allow_faking()
        {
            fakereturn = true;
        }

        // toggle NTRlock on permanently. note, this does not disable core functionality of the patcher
        

        public static void LockON()
        {
            GameMain.Instance.CharacterMgr.status.lockNTRPlay = true;
            Console.WriteLine("NTR lock is set to true");
        }
        // toggle NTRlock off permanently.
        public static void LockOFF()
        {
           
            GameMain.Instance.CharacterMgr.status.lockNTRPlay = false;
            Console.WriteLine("NTR lock is set to false");
        }
    }
}
