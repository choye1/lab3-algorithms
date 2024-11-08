using ListDynamicStructures;
using Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class LinkedListQueueHandler
    {
        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.ToString();
        string fileName;
        string path;
        Logger logger = new Logger();

        List<string> lines = new List<string>();

        public LinkedListQueueHandler(string fileName_)
        {
            fileName = fileName_;
            path = Path.Combine(projectDirectory, fileName);
        }

        // Чтение данных из файла
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

        // Обработка команд очереди
        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();
            CustomQueue<string> queue = new CustomQueue<string>();

            foreach (string line in lines)
            {
                string[] commands = line.Split(" ");
                Stopwatch stopwatch = new Stopwatch();

                try
                {
                    foreach (string command in commands)
                    {
                        if (string.IsNullOrWhiteSpace(command)) continue;

                        stopwatch.Start();

                        if (command.StartsWith("1"))  // Enqueue
                        {
                            string value = command.Substring(2);
                            queue.Enqueue(value);
                            logger.WriteLine($"Выполнена команда Enqueue({value})");
                        }
                        else if (command == "2")  // Dequeue
                        {
                            queue.Dequeue();
                            logger.WriteLine("Выполнена команда Dequeue");
                        }
                        else if (command == "3")  // Top
                        {
                            queue.Top();
                            logger.WriteLine("Выполнена команда Top");
                        }
                        else if (command == "4")  // IsEmpty
                        {
                            bool isEmpty = queue.IsEmpty();
                            logger.WriteLine($"Выполнена команда IsEmpty: {isEmpty}");
                        }
                        else if (command == "5")  // Print
                        {
                            queue.Print();
                            logger.WriteLine("Выполнена команда Print");
                        }
                        else
                        {
                            logger.WriteLine("Некорректный ввод");
                        }

                        stopwatch.Stop();
                        timeForGraph.Add((float)stopwatch.Elapsed.TotalMilliseconds * 100);
                        stopwatch.Reset();
                    }
                }
                catch (Exception ex)
                {
                    logger.WriteLine($"Ошибка выполнения команды: {ex.Message}");
                }
            }

            return timeForGraph;
        }

        // Запуск полной обработки файла
        public float[] HandleFile()
        {
            ReadFile();
            return HandleLine().ToArray();
        }
    }

}
