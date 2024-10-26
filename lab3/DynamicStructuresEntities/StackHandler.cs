using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    internal class StackHandler
    {
        static string projectDirectory = Directory.GetCurrentDirectory();
        static string fileName;
        List<string> lines = new List<string>();
        public StackHandler(string fileName_) 
        {
            fileName = fileName_;
        }

        string path = Path.Combine(projectDirectory, fileName);
        public void ReadFile()
        {
            List<string> lines = new List<string>();
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
                stopwatch.Start();
                foreach (string s in arr)
                {
                    if (s == "1")
                    {
                        Console.WriteLine($"Выполнена команда push({s.Substring(2)})");
                        stack.Push(s.Substring(2));
                    }
                    else if (s == "2")
                    {
                        Console.WriteLine("Выполнена команда pop");
                        stack.Pop();
                    }
                    else if (s == "3")
                    {
                        Console.WriteLine("Выполнена команда top");
                        stack.Top();
                    }
                    else if (s == "4")
                    {
                        Console.WriteLine("Выполнена команда isEmpty");
                        stack.IsEmpty();
                    }
                    else if (s == "5")
                    {
                        Console.WriteLine("Выполнена команда print");
                        stack.Print();
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод");
                    }

                    stack.Print();
                    
                }

                stopwatch.Stop();
                TimeSpan timeSpan = stopwatch.Elapsed;
                stopwatch.Reset();
                timeForGraph.Add((float)timeSpan.TotalMilliseconds * 100);
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
