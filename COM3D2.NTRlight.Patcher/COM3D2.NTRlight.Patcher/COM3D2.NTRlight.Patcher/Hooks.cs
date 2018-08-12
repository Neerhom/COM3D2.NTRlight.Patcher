

namespace COM3D2.NTRlight.Patcher
{
    public static class Hooks
    {

       static bool NTR_lock_base = false;

        static bool NTR_lock_base_got = false;


        //  disable NTR lock  if it's on
        public static void Enable_ntr()

        {
            // get current lock status. there is probably a better place to get it,
            // but this way i don't have to worry about late acquisition
            if (NTR_lock_base_got == false)
            {
                
                NTR_lock_base = GameMain.Instance.CharacterMgr.status.lockNTRPlay;
                NTR_lock_base_got = true;
            }
           
            // temporary disable NTR lock before the method is run
            if (NTR_lock_base)
            {
              
                GameMain.Instance.CharacterMgr.status.lockNTRPlay = false;
               
            }
            

        }

        // enable NTR lock back once target method finished it's thing
        public static void Disable_ntr()
        {
            if (NTR_lock_base)
            {

                GameMain.Instance.CharacterMgr.status.lockNTRPlay = true;

            }
        }

    }
}
