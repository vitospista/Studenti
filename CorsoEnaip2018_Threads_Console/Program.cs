using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorsoEnaip2018_Threads_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread1();
            Thread2();
            
            Console.Read();
        }

        static void Thread1()
        {
            var counter = 0;

            Console.WriteLine("Counter before threads: " + counter);

            var threads = Enumerable
                .Range(1, 5)
                .Select(x => new Thread(() =>
                {
                    try
                    {
                        if (counter > 3)
                            throw new Exception("Eccezione a caso!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    counter++;
                }))
                .ToList();

            try
            {
                foreach (var t in threads)
                    t.Start();

                foreach (var t in threads)
                    t.Join();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Counter after threads: " + counter);
        }

        static void Thread2()
        {
            var threads = Enumerable
                .Range(1, 6)
                .Select(x => new Thread(() =>
                    {
                        for(int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(1);
                            Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}; i: {i}");
                        }
                    }))
                .ToList();

            foreach (var t in threads)
                t.Start();

            foreach (var t in threads)
                t.Join();

            // in questo caso non avrei più esecuzione parallela
            // perché prima di avviare il Thread successivo
            // aspetto che quello precedente abbia finito.
            //foreach(var t in threads)
            //{
            //    t.Start();
            //    t.Join();
            //}

            Console.WriteLine("finished!");
        }
    }
}
