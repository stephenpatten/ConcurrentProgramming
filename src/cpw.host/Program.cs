using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using cpw.lib;

namespace cpw.host
{
    class Program
    {
        static Object obj = new Object();

        static Mutex mutant = new Mutex();

        
        static void Main(string[] args)
        {

            //https://msdn.microsoft.com/en-us/library/system.threading.thread(v=vs.110).aspx

            Console.WriteLine("start");
            try
            {
                ThreadPool.QueueUserWorkItem(ShowThreadInformation);
                var th1 = new Thread(ShowThreadInformation);
                th1.Start();
                var th2 = new Thread(ShowThreadInformation);
                th2.IsBackground = true;
                th2.Start();
                Thread.Sleep(500);
                ShowThreadInformation(null);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            Console.WriteLine("finish");
            Console.ReadKey();
        }

        private static void ShowThreadInformation(Object state)
        {
            mutant.WaitOne();
            try
            {
                var th = Thread.CurrentThread;
                Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
                Console.WriteLine("   Background thread: {0}", th.IsBackground);
                Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
                Console.WriteLine("   Priority: {0}", th.Priority);
                Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
                Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
                Console.WriteLine();
            }
            finally
            {
                mutant.ReleaseMutex();
            }
            //mutant.Close();

            //lock (obj)
            //{
            //    var th = Thread.CurrentThread;
            //    Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
            //    Console.WriteLine("   Background thread: {0}", th.IsBackground);
            //    Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
            //    Console.WriteLine("   Priority: {0}", th.Priority);
            //    Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
            //    Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
            //    Console.WriteLine();
            //}
        }

        private static void ExecuteInForeground()
        {
            DateTime start = DateTime.Now;
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
    }
}
