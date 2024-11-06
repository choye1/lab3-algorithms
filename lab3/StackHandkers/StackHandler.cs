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
    public class StackHandler
    {
        Logger logger = new Logger();

        string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()).ToString();
        string fileName;
        string path;

        List<string> lines = new List<string>();
        public StackHandler(string fileName_) 
        {
            fileName = fileName_;
            path = Path.Combine(projectDirectory, fileName);

        }

        public void ReadFile()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line =reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }

            }

        }

        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();
            for (int i = 0; i < lines.Count; i++)
            {
                CustomStack<string> stack = new CustomStack<string>();
                string[] arr = lines[i].Split(" ");
                Stopwatch stopwatch = new Stopwatch();
                try
                {
                    foreach (string s in arr)
                    {
                        stopwatch.Start();

                        if (s ==null || s.Length == 0) continue;

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

                       // stack.Print();

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

            }

            return timeForGraph;
        }

        public float[] HandleFile()
        {
            ReadFile();
            return (HandleLine()).ToArray();
        }

    }

}
