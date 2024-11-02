using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Loggers;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DynamicStructuresEntities
{
    public class QueueHandlerConsole
    {
        string[] command;
        Logger logger = new Logger();

        CustomQueue<string> queue;

        public QueueHandlerConsole(string[] command_, CustomQueue<string> queue)
        {
            command = command_;
            this.queue = queue;
        }



        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {
                foreach (string s in command)
                {
                    if (s == null || s.Length == 0) continue;

                    if (s.StartsWith("1"))
                    {
                        queue.Enqueue(s.Substring(2));
                        logger.WriteLine($"Выполнена команда Enqueue({s.Substring(2)})");
                    }
                    else if (s == "2")
                    {
                        queue.Dequeue();
                        logger.WriteLine("Выполнена команда Dequeue");
                    }
                    else if (s == "3")
                    {
                        queue.Top();
                        logger.WriteLine("Выполнена команда top");

                    }
                    else if (s == "4")
                    {
                        queue.IsEmpty();
                        logger.WriteLine("Выполнена команда isEmpty");

                    }
                    else if (s == "5")
                    {
                        logger.WriteLine("Выполнена команда print");
                        queue.Print();


                    }
                    else
                    {
                        logger.WriteLine("Некорректный ввод");
                    }

                    //queue.Print();

                }
            }

            catch (Exception)
            {
                logger.Write("Некорректный ввод");
            }

            stopwatch.Stop();
            TimeSpan timeSpan = stopwatch.Elapsed;
            stopwatch.Reset();
            timeForGraph.Add((float)timeSpan.TotalMilliseconds * 100);


            return timeForGraph;
        }

        public float[] Handle()
        {
            return (HandleLine()).ToArray();
        }

    }
}
