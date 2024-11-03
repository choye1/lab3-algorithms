using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using DynamicStructuresEntities;
using Loggers;
using part4;

namespace lab3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main();
        }


        CustomQueue<string> queue = new CustomQueue<string>();
        CustomStack<string> stack = new CustomStack<string>();

        public void Main()
        {
            Logger logger = new Logger();
            logger.RemoveLogs();
            string namefile = "a.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ КУЕУЕ
            string namefileForStack = "b.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ СТЕКА

            //float[] timeForGraphQueue = new QueueHandler(namefile).HandleFile();

            //logger.WriteLine("^Queue^");
            //logger.WriteLine("\\/Stack\\/");

            //float[] timeForGraphStack = new StackHandler(namefileForStack).HandleFile();

            WriteArray(logger.Read());

        }

        private void Write(string str)
        {
            tbConsole.Text += str;
        }

        private void WriteLine(string str)
        {
            tbConsole.Text += str + "\n";
        }

        private void WriteArray(string[] arr)
        {
            tbConsole.Text += "";

            foreach (string i in arr)
            {
                tbConsole.Text += i + " " + "\n";
            }

            tbConsole.Text += "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ModesSelector.IsChecked == true)
                {
                    FourTaskHandler();

                }
                else
                {
                    CommandHandler();
                }
            }
            catch { throw new Exception("Некорректный ввод."); }

        }

        private void FourTaskHandler()
        {
            int numberOfTask = int.Parse(tbCommand.Text.Split(",")[0]);
            string args = tbCommand.Text.Split(",")[1];

            part4.Task task = GetTask(numberOfTask);
            task.
        }

        private part4.Task GetTask(int numOfTask)
        {

            return new Task2<string>();
        } 


        private void CommandHandler()
        {
            try
            {
                Logger logger = new Logger();
                logger.RemoveLogs();

                string[] command = ParseCommand(tbCommand.Text); //Команда имеет следующую структуру: [stack/queue] command [args]



                if (command[0] == "q")
                {
                    QueueHandlerConsole queueHandlerConsole = new QueueHandlerConsole(GlueCommandAndArgs(command), queue);
                    queueHandlerConsole.Handle();
                    WriteArray(logger.Read());

                }
                else if (command[0] == "s")
                {
                    StackHandlerConsole stackHandler = new StackHandlerConsole(GlueCommandAndArgs(command), stack);
                    stackHandler.Handle();
                    WriteArray(logger.Read());
                }
                else { throw new Exception("Некорректный ввод, используйте синтаксис [queue/stack] command [args]"); }
            }
            catch (Exception ex)
            {
                tbConsole.Text = ex.Message;
            }
        }

        private string[] ParseCommand(string command)

        {   //Короче, тема такая: 1ый элемент массива может быть либо 0 либо 1, если 0 - то комманда для очереди, если 1 - то для стека. 2 элемент - комманда:
            // 1 - вставка, 2 - удаление, 3 – просмотр начала очереди, 4 – проверка на пустоту, 5 - печать   <-- для Queue
            // 1 - Push(elem), 2 - Pop(), 3 - Top(), 4 - isEmpty(), 5 - Print()                              <-- для стека

            List<string> ParsedCommand = new List<string>();
            string[] args = command.Split(' ');
            if (args.Length < 2) { throw new Exception("Некорректный ввод адресата комманды, используйте следующий синтаксис: [stack/queue] command [args]"); }
            string addresseeCommand = args[0];
            string commandName = args[1];
            args[0] = string.Empty;
            args[1] = string.Empty;


            switch (addresseeCommand)
            {
                case ("stack"):
                    ParsedCommand.Add("s");
                    break;
                case ("queue"):
                    ParsedCommand.Add("q");
                    break;
                default: throw new Exception("Некорректный ввод адресата комманды, используйте следующий синтаксис: [stack/queue] command [args]");
            }

            ParsedCommand.Add(GiveCodeOfCommand(commandName));

            for (int i = 2; i < args.Length; i++)
            {
                if (args[i] != string.Empty)
                {
                    ParsedCommand.Add(args[i]);
                }
            }

            return ParsedCommand.ToArray();
        }

        private string GiveCodeOfCommand(string commandName)
        {
            commandName = commandName.ToLower();
            switch (commandName)
            {
                case ("push" or "add" or "queue"):
                    return "1,";

                case ("pop" or "remove" or "dequeue"):
                    return "2";

                case ("top"):
                    return "3";

                case ("isempty"):
                    return "4";

                case ("print"):
                    return "5";

                default: throw new Exception("Некорректный ввод, используйте комманды: push, pop, top, isEmpty, print, dequeue, queue, add, remove.");
            }
        }


        private string WriteCommandToFile(string[] command)
        {
            string filename = "commandList";

            string path = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()).ToString()).ToString() + "\\" + filename;
            File.Delete(path);

            StringBuilder commandForWrite = new StringBuilder();
            foreach (string line in command)
            {
                if (line == "q" || line == "s") continue;

                commandForWrite.AppendLine(line);
            }

            File.WriteAllText(path, commandForWrite.ToString());

            return filename;
        }

        private string[] GlueCommandAndArgs(string[] command) //Единственное, что делает этот метод - подгоняет синтаксис под "1,5341"
        {
            List<string> result = new List<string>();

            if (command.Length > 2)
            {
                result.Add(command[1] + command[2]);
            }

            else
            {
                result.Add(command[1]);
            }

            return result.ToArray();
        }

        private void UsingCommandFile(object sender, RoutedEventArgs e)
        {

            Logger logger = new Logger();
            logger.RemoveLogs();
            string namefile = "queue.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ КУЕУЕ
            string namefileForStack = "stack.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ СТЕКА

            float[] timeForGraphQueue = new QueueHandler(namefile).HandleFile();
            WriteGraph(timeForGraphQueue, "queue");
            logger.WriteLine("^Queue^");
            logger.WriteLine("\\/Stack\\/");

            float[] timeForGraphStack = new StackHandler(namefileForStack).HandleFile();
            WriteGraph(timeForGraphStack, "stack");

            WriteArray(logger.Read());
        }

        private void WriteGraph(float[] times, string addreess)
        {
            List<float> dataX = new List<float>();
            for (int i = 0; i < times.Length; i++) { dataX.Add((float)i); }
            if (addreess == "queue")
            {
                GraphQueue.Plot.Add.Scatter(dataX.ToArray(), times);
                GraphQueue.Plot.Axes.SetLimits(-1, dataX.Max() + 1, times.Min() - 2, times.Max() + 2);
                GraphQueue.Refresh();

            }
            else
            {
                GraphStack.Plot.Add.Scatter(dataX.ToArray(), times);
                GraphStack.Plot.Axes.SetLimits(-1, dataX.Max() + 1, times.Min() - 2, times.Max() + 2);
                GraphStack.Refresh();
            }

        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ModesSelector.IsChecked == true)
            {
                ModesSelector.Content = ("4 часть. Используйте: [Номер задания], [Входные данные через пробел] ");
            }

            else
            {
                ModesSelector.Content = ("Консоль. Используйте: [queue/stack] command [args] ");
            }
        }
    }
}