using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Loggers;
using System.Text;
using System.Threading.Tasks;
using ListDynamicStructures;

namespace StackHandlers
{
    public class StackHandlerConsole
    {
        Logger logger = new Logger();


        string[] command;
        CustomStack<string> stack;

        public StackHandlerConsole(string[] command, CustomStack<string> stack)
        {
            this.command = command;
            this.stack = stack;

        }



        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();

            Stopwatch stopwatch = new Stopwatch();
            try
            {
                foreach (string s in command)
                {
                    stopwatch.Start();

                    if (s == null || s.Length == 0) continue;

                    if (s.StartsWith("1"))
                    {
                        logger.WriteLine($"Выполнена команда push({s.Substring(2)})");
                        stack.Push(s.Substring(2));
                    }
                    else if (s == "2")
                    {
                        logger.WriteLine("Выполнена команда pop");
                        stack.Pop();
                    }
                    else if (s == "3")
                    {
                        logger.WriteLine("Выполнена команда top");
                        stack.Top();
                    }
                    else if (s == "4")
                    {
                        logger.WriteLine("Выполнена команда isEmpty");
                        stack.IsEmpty();
                    }
                    else if (s == "5")
                    {
                        logger.WriteLine("Выполнена команда print");
                        stack.Print();
                    }
                    else
                    {
                        logger.WriteLine("Некорректный ввод");
                    }

                    //stack.Print();

                    stopwatch.Stop();
                    TimeSpan timeSpan = stopwatch.Elapsed;
                    stopwatch.Reset();
                    timeForGraph.Add((float)timeSpan.TotalMilliseconds * 100);
                }
            }
            catch (Exception)
            {
                logger.WriteLine("Некорректный ввод");

            }

            


            return timeForGraph;
        }

        public float[] Handle()
        {
            return (HandleLine()).ToArray();
        }

    }

}
