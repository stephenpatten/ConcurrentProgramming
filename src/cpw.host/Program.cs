using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cpw.lib;

namespace cpw.host
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start");
            try
            {
                var mutex = new MutexTest();
                mutex.CriticalRegionTest1();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Console.WriteLine("finish");
            Console.ReadKey();
        }
    }
}
