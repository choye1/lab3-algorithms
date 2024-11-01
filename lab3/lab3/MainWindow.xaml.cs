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
            string namefile = "a.txt"; //СЮДА ХУЯЧИМ ИМЯ ФАЙЛА, ИЗ КОТОРОГО ЧИТАЕМ ДАННЫЕ
            float[] result = new QueueHandler(namefile).HandleFile();

            WriteArray(result);

            //float[] result2 = new StackHandler(namefile).HandleFile();

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
                tbConsole.Text += arr[i] + " ";
            }

            tbConsole.Text += "\n";
        }
    }
}