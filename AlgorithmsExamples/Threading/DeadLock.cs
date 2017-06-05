using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// http://www.c-sharpcorner.com/blogs/deadlock-and-way-to-avoid
    /// </summary>
    public class DeadLock
    {
        private static object lockA = new object();
        private static object lockB = new object();

        #region Deallock Avoidance  
        private static void MyWork1()
        {
            lock (lockA)
            {
                Console.WriteLine("Trying to acquire lock on lockB");

                // This will try to acquire lock for 5 seconds.  
                if (Monitor.TryEnter(lockB, 5000))
                {
                    try
                    {
                        Console.WriteLine("In DoWork1 Critical Section.");
                        // Access some shared resource here.  
                    }
                    finally
                    {
                        Monitor.Exit(lockB);
                        Console.WriteLine("In DoWork1 Monitor Exit.");
                    }
                }
                else
                {
                    // Print lock not able to acquire message.  
                    Console.WriteLine("Unable to acquire lock, exiting MyWork1.");
                }
            }
        }

        private static void MyWork2()
        {
            lock (lockB)
            {
                Console.WriteLine("Trying to acquire lock on lockA");
                lock (lockA)
                {
                    Console.WriteLine("In MyWork2 Critical Section.");
                    // Access some shared resource here.  
                }
            }
        }

        public static void ExecuteDeadlockAvoidance()
        {
            // Initialize thread with address of DoWork1  
            Thread thread1 = new Thread(MyWork1);

            // Initilaize thread with address of DoWork2  
            Thread thread2 = new Thread(MyWork2);

            // Start the Threads.  
            thread1.Start();
            thread2.Start();

            //If we want multiple threads to finish their work and then proceed to the next phase of processing,
            //then we might want to use thread join. 
            thread1.Join();
            thread2.Join();

            Console.WriteLine("Done Processing...");
        }

        #endregion

    }
}
