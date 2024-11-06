using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Loggers;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using ListDynamicStructures;

namespace DynamicStructuresEntities
{
    public class QueueHandler
    {
        string projectDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()).ToString();
        string fileName;
        string path;
        Logger logger = new Logger();

        List<string> lines = new List<string>();
        public QueueHandler(string fileName_)
        {
            fileName = fileName_;
            path = Path.Combine(projectDirectory, fileName);

        }



        public void ReadFile()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string? line;
                while ((line = reader.ReadLine()) != null)
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
                CustomQueue<string> queue = new CustomQueue<string>();
                string[] arr = lines[i].Split(" ");
                Stopwatch stopwatch = new Stopwatch();
                try
                {
                    foreach (string s in arr)
                    {
                        stopwatch.Start();

                        if (s ==null  || s.Length == 0) continue;

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
                            queue.Print();
                            logger.WriteLine("Выполнена команда print");

                        }
                        else
                        {
                            logger.WriteLine("Некорректный ввод");
                        }

                        //queue.Print();

                        stopwatch.Stop();
                        TimeSpan timeSpan = stopwatch.Elapsed;
                        stopwatch.Reset();
                        timeForGraph.Add((float)timeSpan.TotalMilliseconds * 100);

                    }
                }

                catch (Exception)
                {
                    logger.Write("Некорректный ввод");
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
