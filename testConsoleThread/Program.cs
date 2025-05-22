using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace testConsoleThread
{
    class Program
    {
        volatile static int counter = 0;
        static void Main(string[] args)
        {
            List<Task> allTasks = new List<Task>();
            for (int i = 0; i < 10; i++) {
                Task t1 = new Task(() => {
                    count();
                });
                allTasks.Add(t1);
                t1.Start();
            }
            Task.WaitAll(allTasks.ToArray());

            Debug.WriteLine(counter);

            Console.Read();
        }

        public static void count() {
            for (int i = 0; i < 1000000; i++) {
                counter++;
            }
        }
    }
}
