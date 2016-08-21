using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TasksDeadlock
{
    class Program
    {
        static void Main(string[] args)
        {
            int taskCount = 6;
            var tasks = new Task[taskCount];
            var autoResetEvent = new AutoResetEvent(false);
            for (int i = 0; i < taskCount; i++)
            {
                tasks[i] = Task.Factory.StartNew(state =>
                {
                    var index = (int)state;
                    if (index < 3)
                    {
                        tasks[(index + 1) % 3].Wait();
                    }
                    else if (index == 3)
                    {
                        Task.Factory.StartNew(() =>
                        {
                            while (true) { }
                        }).Wait();
                    }
                    else
                    {
                        autoResetEvent.WaitOne();
                    }
                }, i);
            }

            Task.WaitAll(tasks);

            autoResetEvent.Set();
        }
    }
}
