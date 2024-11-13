using System;
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
using ListDynamicStructures;
using Loggers;
using part4;
using ScottPlot;
using StackHandlers;


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
            
            
            GraphQueue.Plot.XLabel("Комманда №");
            GraphQueue.Plot.YLabel("Время мс*100");
            GraphStack.Plot.XLabel("Комманда №");
            GraphStack.Plot.YLabel("Время мс*100");
            Main();

        }


        CustomQueue<string> queue = new CustomQueue<string>();
        CustomStack<string> stack = new CustomStack<string>();

        public void Main()
        {

            Logger logger = new Logger();
            logger.RemoveLogs();

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
                CommandHandler();
            }

            catch (Exception ex)
            {
                tbConsole.Text = "";
                WriteLine(ex.Message);
            }

        }





        private void CommandHandler()
        {
            try
            {
                tbConsole.Text = "";
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
            if (args.Length < 2) { throw new Exception("Некорректный ввод адресата комманды, \nиспользуйте следующий синтаксис: [stack/queue] command [args]"); }
            string addresseeCommand = args[0];
            string commandName = args[1];
            args[0] = string.Empty;
            args[1] = string.Empty;


            switch (addresseeCommand)
            {
                case ("stack" or "s" or "st"):
                    ParsedCommand.Add("s");
                    break;
                case ("queue" or "q" or "qu"):
                    ParsedCommand.Add("q");
                    break;
                default: throw new Exception("Некорректный ввод адресата комманды, \nиспользуйте следующий синтаксис: [stack/queue] command [args]");
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
                case ("push" or "add" or "enqueue"):
                    return "1,";

                case ("pop" or "remove" or "dequeue"):
                    return "2";

                case ("top"):
                    return "3";

                case ("isempty"):
                    return "4";

                case ("print"):
                    return "5";

                default: throw new Exception("Некорректный ввод, используйте комманды: \n push, pop, top, isEmpty, print, \n dequeue, queue, add, remove.");
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

        float maxOfTimesQ = 0;
        float maxOfTimesS = 0;

        private void UsingCommandFile(object sender, RoutedEventArgs e)
        {
            tbConsole.Text = "";
            GraphQueue.Plot.Clear();
            GraphStack.Plot.Clear();
            maxOfTimesS = 0;
            maxOfTimesQ = 0;
            Logger logger = new Logger();
            logger.RemoveLogs();
            string namefile = "queue.txt"; //СЮДА ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ КУЕУЕ
            string namefileForStack = "stack.txt"; //СЮДА ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ СТЕКА

            float[] timeForGraphQueue = new QueueHandler(namefile).HandleFile();
            WriteGraph(timeForGraphQueue, "queue", "На списках");
            WriteGraph(new LinkedListQueueHandler(namefile).HandleFile(), "queue", "На Linked-List");
            WriteGraph(new StandartQueueHandler(namefile).HandleFile(), "queue", "На Queue");

            logger.WriteLine("^Queue^"); 
            logger.WriteLine("\\/Stack\\/");

            float[] timeForGraphStack = new StackHandler(namefileForStack).HandleFile();
            WriteGraph(timeForGraphStack, "stack", "На списках");
            WriteGraph(new LinkedListStackHandler(namefileForStack).HandleFile(), "stack", "На Linked-List");
            WriteGraph(new StandartStackHandler(namefileForStack).HandleFile(), "stack", "На Stack-e");



            WriteArray(logger.Read());
        }

       
        private void WriteGraph(float[] times, string addreess, string nameOfSrtuct)
        {

            List<float> dataX = new List<float>();
            for (int i = 1; i < times.Length+1; i++) { dataX.Add((float)i); }
            if (addreess == "queue")
            {
                maxOfTimesQ = times.Max() > maxOfTimesQ ? times.Max() : maxOfTimesQ;
                var scat = GraphQueue.Plot.Add.Scatter(dataX.ToArray(), times);
                scat.Label = nameOfSrtuct;
                GraphStack.Plot.ShowLegend();
                GraphQueue.Plot.Legend.Alignment = Alignment.UpperLeft;
                GraphQueue.Refresh();

            }
            else
            {
                maxOfTimesS = times.Max() > maxOfTimesS ? times.Max() : maxOfTimesS;
                var scat = GraphStack.Plot.Add.Scatter(dataX.ToArray(), times);
                scat.Label = nameOfSrtuct;
                GraphStack.Plot.ShowLegend();
                GraphStack.Plot.Legend.Alignment = Alignment.UpperLeft;
                GraphStack.Refresh();
            }

            GraphQueue.Plot.Axes.SetLimits(-1, dataX.Max() + 1, 0, maxOfTimesQ + 2);
            GraphQueue.Refresh();

            GraphStack.Plot.Axes.SetLimits(-1, dataX.Max() + 1, 0, maxOfTimesS + 2);
            GraphStack.Refresh();


        }

        private void tbCommandKeydown(object sender, KeyEventArgs e)
        {
            if (tbCommand.Text!="" && e.Key == Key.Enter)
            {
                Button_Click(sender, e);
            }
        }
    }
}