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
using DynamicStructuresEntities;
using Loggers;

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



        public void Main()
        {
            Logger logger = new Logger();
            string namefile = "a.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ КУЕУЕ
            string namefileForStack = "b.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ ДЛЯ СТЕКА

            float[] timeForGraphQueue = new QueueHandler(namefile).HandleFile();

            logger.WriteLine("^Queue^");
            logger.WriteLine("\\/Stack\\/");

            float[] timeForGraphStack = new StackHandler(namefileForStack).HandleFile();

            // WriteArray(result2);

        }

        private void Write(string str)
        {
            tbConsole.Text += str;
        }

        private void WriteLine(string str)
        {
            tbConsole.Text += str + "\n";
        }

        private void WriteArray(float[] arr)
        {
            tbConsole.Text += "\n";

            foreach(int i  in arr)
            {
                tbConsole.Text += i + " ";
            }

            tbConsole.Text += "\n";
        }
    }
}