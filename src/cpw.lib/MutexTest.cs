using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace cpw.lib
{
    //http://stackoverflow.com/questions/5754879/usage-of-mutex-in-c-sharp

    public class MutexTest
    {
        //Create a mutex which is in the signaled state
        private readonly Mutex _mutant = new Mutex();

        //Signaling and waiting

        //Signaled

        //Nonsignaled

        public void CriticalRegionTest1()
        {
            _mutant.WaitOne();
            try
            {
                //Critical Region
                Console.WriteLine($"Current tread {Thread.CurrentThread.ManagedThreadId.ToString()}");
            }
            finally
            {
                _mutant.ReleaseMutex();
            }
            
        }

    }
}
