using Loggers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicStructuresEntities
{
    public class StandartQueueHandler
    {
        private Logger logger = new Logger();
        private string projectDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.ToString();
        private string fileName;
        private string path;

        private List<string> lines = new List<string>();

        public StandartQueueHandler(string fileName_)
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

        // Обработка команд очереди
        public List<float> HandleLine()
        {
            List<float> timeForGraph = new List<float>();

            foreach (string line in lines)
            {
                Queue<string> queue = new Queue<string>();
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
                            logger.WriteLine($"Выполнена команда enqueue({value})");
                        }
                        else if (command == "2")  // Dequeue
                        {
                            if (! (queue.Count == 0))
                            {
                                queue.Dequeue();
                                logger.WriteLine("Выполнена команда dequeue");
                            }
                            else
                            {
                                logger.WriteLine("Ошибка: Попытка удаления из пустой очереди");
                            }
                        }
                        else if (command == "3")  // Peek (Top аналог в очереди)
                        {
                            if (!(queue.Count == 0))
                            {
                                string front = queue.Peek();
                                logger.WriteLine($"Выполнена команда top: {front}");
                            }
                            else
                            {
                                logger.WriteLine("Ошибка: Попытка чтения из пустой очереди");
                            }
                        }
                        else if (command == "4")  // IsEmpty
                        {
                            bool isEmpty = (queue.Count == 0);
                            logger.WriteLine($"Выполнена команда isEmpty: {isEmpty}");
                        }
                        else if (command == "5")  // Print
                        {
                            logger.WriteLine("Выполнена команда print:");
                            logger.Write(queue.ToString());
                            logger.Write("\n");
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
