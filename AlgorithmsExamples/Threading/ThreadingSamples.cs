using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    public static class ThreadingSamples
    {
        public static void ThreadingWithTask()
        {
            var t1 = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Task 1");
            });

            var t2 = t1.ContinueWith(delegate
            {
                //simulate compute intensive
                Thread.Sleep(5000);
                return "Task 2 finished";
            });

            //Main thread will wait at "t2.Result" until "t2" finishes execution and its "return" statement is executed
            string resultStr = t2.Result;
            Console.WriteLine(string.Format("Result of t2 is {0}", resultStr));

            t2.ContinueWith(delegate
            {
                Console.WriteLine("t2 ContinueWith finished");
            });
            Console.WriteLine("Waiting for t2 ContinueWith");
        }

        public static void ThreadingWithParallel()
        {
            Stopwatch watch;
            watch = new Stopwatch();
            watch.Start();

            //serial implementation
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Serial => " + i);
                //Do stuff
            }
            watch.Stop();
            Console.WriteLine("Serial Time: " + watch.Elapsed.Seconds.ToString());

            //parallel implementation
            watch = new Stopwatch();
            watch.Start();
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                Console.WriteLine("Parallel => " + i);
                //Do stuff with i
            }
            );
            watch.Stop();
            Console.WriteLine("Parallel Time: " + watch.Elapsed.Seconds.ToString());

            Parallel.For(0, 10, (int i, ParallelLoopState loopState) =>
            {
                if (i == 5)
                {
                    loopState.Break();
                    //or loopState.Stop();

                    //Break ensures that all earlier iterations that started in the loop are executed before exiting the loop.
                    //The Stop method makes no such guarantees; it basically says that this loop is done and should exit as soon as possible.

                    Console.WriteLine(string.Format("Parallel LoopState => {0}", i));
                    return; // to ensure that this iteration also returns
                }
                //do stuff
                Console.WriteLine(string.Format("Parallel LoopState => {0}", i));
            });
        }
    }
}
