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
    /// http://www.c-sharpcorner.com/UploadFile/ff0d0f/autoresetevent-and-manualresetevent-in-C-Sharp/
    /// When we use "AutoResetEvent" for every WaitOne, we need a "Set" to revoke. 
    /// In ManualResetEvent, once we call the "Set", all "WaitOne" will execute until we call "Close".
    /// In ManualResetEvent, 1 Set() method will revoke all the WaitOne() methods and this is the main difference between AutoResetEvent and ManualResetEvent.
    /// </summary>
    public class AutoManualResetEventSample
    {
        //static AutoResetEvent objSync = new AutoResetEvent(false);
        static ManualResetEvent objSync = new ManualResetEvent(false);
        public static void Init()
        {
            new Thread(SomeMethod).Start();//invoke SomeMethod in a different thread

            Console.WriteLine("Before first Set");
            Console.ReadLine();
            //signal to start again
            Console.WriteLine("Before second Set");
            objSync.Set(); //WaitOne at 1

            Console.ReadLine();
            //signal to start again
            objSync.Set(); //WaitOne at 2
        }

        private static void SomeMethod()
        {
            Console.WriteLine("Starting 1...");
            objSync.WaitOne();
            Console.WriteLine("Finishing 1...");
            Console.WriteLine("Starting 2...");
            objSync.WaitOne();
            Console.WriteLine("Finishing 2...");
        }
    }
}
