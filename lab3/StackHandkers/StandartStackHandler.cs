using Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackHandlers

{
    public class StandartStackHandler
    {
        private Logger logger = new Logger();
        private string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.ToString();
        private string fileName;
        private string path;

        private List<string> lines = new List<string>();

        public StandartStackHandler(string fileName_)
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
                Stack<string> stack = new Stack<string>();
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
                            if (stack.Count > 0)
                            {
                                stack.Pop();
                                logger.WriteLine("Выполнена команда pop");
                            }
                            else
                            {
                                logger.WriteLine("Ошибка: Попытка удаления из пустого стека");
                            }
                        }
                        else if (command == "3")  // Top (Peek)
                        {
                            if (stack.Count > 0)
                            {
                                string top = stack.Peek();
                                logger.WriteLine($"Выполнена команда top: {top}");
                            }
                            else
                            {
                                logger.WriteLine("Ошибка: Попытка чтения из пустого стека");
                            }
                        }
                        else if (command == "4")  // IsEmpty
                        {
                            bool isEmpty = stack.Count == 0;
                            logger.WriteLine($"Выполнена команда isEmpty: {isEmpty}");
                        }
                        else if (command == "5")  // Print
                        {
                            logger.WriteLine("Выполнена команда print:");
                            foreach (var item in stack)
                            {
                                Console.Write($"{item} ");
                            }
                            Console.WriteLine();
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
