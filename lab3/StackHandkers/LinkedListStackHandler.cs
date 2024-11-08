using ListDynamicStructures;
using Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHandlers
{
    public class LinkedListStackHandler
    {
        Logger logger = new Logger();

        string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.ToString();
        string fileName;
        string path;

        List<string> lines = new List<string>();

        public LinkedListStackHandler(string fileName_)
        {
            fileName = fileName_;
            path = Path.Combine(projectDirectory, fileName);
        }

        // Чтение файла с командами
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

        // Обработка команд стека
        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();

            foreach (string line in lines)
            {
                CustomStack<string> stack = new CustomStack<string>();
                string[] commands = line.Split(" ");
                Stopwatch stopwatch = new Stopwatch();

                try
                {
                    foreach (string command in commands)
                    {
                        if (string.IsNullOrWhiteSpace(command)) continue;

                        stopwatch.Start();

                        if (command.StartsWith("1"))  // Push
                        {
                            string value = command.Substring(2);
                            stack.Push(value);
                            logger.WriteLine($"Выполнена команда push({value})");
                        }
                        else if (command == "2")  // Pop
                        {
                            stack.Pop();
                            logger.WriteLine("Выполнена команда pop");
                        }
                        else if (command == "3")  // Top
                        {
                            stack.Top();
                            logger.WriteLine("Выполнена команда top");
                        }
                        else if (command == "4")  // IsEmpty
                        {
                            bool isEmpty = stack.IsEmpty();
                            logger.WriteLine($"Выполнена команда isEmpty: {isEmpty}");
                        }
                        else if (command == "5")  // Print
                        {
                            stack.Print();
                            logger.WriteLine("Выполнена команда print");
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
