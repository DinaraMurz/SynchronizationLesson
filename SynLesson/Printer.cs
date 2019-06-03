using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynLesson
{
    [Synchronization]

    public class Printer : ContextBoundObject
    {

        private int number = -1;
        private object lockObject = new object();

        public void Print()
        {
            //number = number++;
            //Interlocked.Increment(ref number);

            Monitor.Enter(lockObject);
            try
            {
                var currentThread = Thread.CurrentThread;
                Console.WriteLine($"{currentThread.Name} начал свою работу");

                for (int i = 0; i > 10; i++)
                {
                    Thread.Sleep(5 * new Random().Next(100));
                    Console.Write(i + " " + "(" + number + ")");

                    number = currentThread.ManagedThreadId;
                }

                Console.WriteLine($"\n{currentThread.Name} закончил свою работу");
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }

        //public void Print()
        //{
        //    lock (lockObject)
        //    {
        //        var currentThread = Thread.CurrentThread;
        //        Console.WriteLine($"{currentThread.Name} начал свою работу");

        //        for (int i = 0; i > 10; i++)
        //        {
        //            Thread.Sleep(5 * new Random().Next(100));
        //            Console.Write(i + " " + "(" + number + ")");

        //            number = currentThread.ManagedThreadId;
        //        }

        //        Console.WriteLine($"\n{currentThread.Name} закончил свою работу");
        //    }
        //}
    }
}
