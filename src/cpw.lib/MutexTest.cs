using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cpw.lib
{
    public class MutexTest
    {
        //Signaling and waiting

        //Signaled

        //Nonsignaled

        public void CriticalRegionTest1()
        {
            //Create a mutex which is in the signaled state
            Mutex mutant = new Mutex();

            mutant.WaitOne();
            try
            {
                //Critical Region
                
            }
            finally
            {
                mutant.ReleaseMutex();
            }

            mutant.Close();
        }

    }
}
