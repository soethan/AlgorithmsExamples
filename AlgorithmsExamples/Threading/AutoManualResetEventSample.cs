using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgorithmsExamples
{
    /// <summary>
    /// http://www.dotnetinterviewquestions.in/article_c-threading-interview-questions:-what-is-the-difference-between-autoresetevent-and-manualresetevent_118.html
    /// When we use "AutoResetEvent" for every WaitOne, we need a "Set" to revoke. 
    /// In "ManualResetEvent", once we call the "Set", all "WaitOne" will execute until we call "Close".
    /// </summary>
    public class AutoManualResetEventSample
    {
        //static AutoResetEvent objAuto = new AutoResetEvent(false);
        static ManualResetEvent objAuto = new ManualResetEvent(false);
        public static void Init()
        {
            new Thread(SomeMethod).Start();//invoke SomeMethod in a different thread

            Console.ReadLine();
            //signal to start again
            objAuto.Set(); //WaitOne at 1

            Console.ReadLine();
            //signal to start again
            objAuto.Set(); //WaitOne at 2
        }

        private static void SomeMethod()
        {
            Console.WriteLine("Starting 1...");
            objAuto.WaitOne();
            Console.WriteLine("Finishing 1...");
            Console.WriteLine("Starting 2...");
            objAuto.WaitOne();
            Console.WriteLine("Finishing 2...");
        }
    }
}
