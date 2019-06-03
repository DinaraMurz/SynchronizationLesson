using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SynLesson
{
    class Program
    {
        static void Main(string[] args)
        {
            var threads = new Thread[20];
            var printer = new Printer();
            
                for (int i = 0; i < threads.Length; i++)
                {
                    var thread = new Thread(printer.Print);
                    thread.Name = $"поток номер {thread.ManagedThreadId}";

                    //adding thread
                }

                foreach (var thread in threads)
                {
                    thread.Start();
                }

                Console.ReadLine();
            
        }
    }
}
