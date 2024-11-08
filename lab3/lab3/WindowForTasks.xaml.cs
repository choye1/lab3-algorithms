using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using RPNEntities;
using System.Threading.Tasks;
using System.Windows;
using part4;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;

namespace lab3
{
    /// <summary>
    /// Логика взаимодействия для WindowForTasks.xaml
    /// </summary>
    public partial class WindowForTasks : Window
    {
        public WindowForTasks()
        {
            InitializeComponent();
        }

        private void BtStartFourPart(object sender, RoutedEventArgs e)
        {
            int numTask = int.Parse(NumberOfTask.Text);
            string[] array1 = List1.Text.Split(',', ' ', ';');
            string[] array2 = List2.Text.Split(',', ' ', ';');
            try
            {
                List<string> result = StartTask(numTask, array1.ToList(), array2.ToList());

                Write(result);
            }

            catch
            {
                throw new Exception("Некорректный ввод");
            }


        }

        private List<string> StartTask(int num, List<string> array1, List<string> List2)
        {
            List<string> result = new List<string>();
            array1 = RemoveSpace(array1);
            List2 = RemoveSpace(List2);
            switch (num)
            {
                case 1:
                    result = new Task1<string>() { }.GetResult(array1);
                    break;

                case 2:
                    result = new Task2<string>() { }.GetResult(array1);
                    break;

                case 3:
                    result.Add(new Task3<string>() { }.GetResult(array1).ToString());
                    break;

                case 4:
                    result = new Task4<string>() { }.GetResult(array1);
                    break;

                case 5:
                    result = new Task5<string>() { }.GetResult(array1, List2[0]);
                    break;

                case 6:
                    result = new Task6<string>() { }.GetResult(array1, List2[0]);
                    break;

                case 7:
                    result = new Task7<string>() { }.GetResult(array1, List2[0]);
                    break;

                case 8:
                    result = new Task8<string>() { }.GetResult(array1, List2[0], List2[1]);
                    break;

                case 9:
                    result = new Task9<string>() { }.GetResult(array1, List2);
                    break;

                case 10:
                    result = Give10TaskResult(array1, List2[0]);
                    break;

                case 11:
                    result = new Task11<string>() { }.GetResult(array1);
                    break;

                case 12:
                    result = new Task12<string>() { }.GetResult(array1, List2[0], List2[1]);
                    break;

                default:
                    throw new Exception("Нет задания под номером" + num);
            }

            return result;
        }

        private List<string> RemoveSpace(List<string> list)
        {
            List<string> result = new List<string>();

            foreach (string s in list)
            {
                result.Add(s.Replace(" ", ""));
            }
            return result;
        }

        private List<string> Give10TaskResult(List<string> array1, string val)
        {
            List<string> result = new List<string>();
            var res = new Task10<string>() { }.GetResult(array1, val);
            foreach (var r in res)
            {
                foreach (var s in r)
                {
                    result.Add(s);
                }

                result.Add(" И ");
            }

            return result;
        }

        private void Write(List<string> list)
        {
            TbOut.Text += "Result:\n";

            foreach (var s in list)
            {
                TbOut.Text += s + " ";
            }

            TbOut.Text += "\n";


        }

        private void BtStartRPN(object sender, RoutedEventArgs e)
        {
            try
            {
                string expression = tbRpnIn.Text;
                RPNHandler rh = new RPNHandler(expression);
                string rpn = rh.GetRPN();
                string result = rh.GetResult().ToString();
                TbOut.Text = "Result: " + result + "\nRPN:" + rpn;
            }
            catch (Exception ex) 
            {
                TbOut.Text = ex.Message;
            }

        }
    }
}
