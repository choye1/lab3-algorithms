using System;
using System.IO;
using DynamicStructuresEntities;
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
using ScottPlot;

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

        private void tbCommandKeydown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtStartRPN(sender, e);
            }
        }

        private void tbTaskKeydown(object sender, KeyEventArgs e)
        {
            if (NumberOfTask.Text != "" && List1.Text != "" && e.Key == Key.Enter)
            {
                BtStartFourPart(sender, e);
            }
        }



        private void BtStartFourPart(object sender, RoutedEventArgs e)
        {
            try
            {
                int numTask = int.Parse(NumberOfTask.Text);
                string[] array1 = List1.Text.Split(',', ' ', ';');
                string[] array2 = List2.Text.Split(',', ' ', ';');

                List<string> result = StartTask(numTask, array1.ToList(), array2.ToList()).ToList;

                Write(result);
            }

            catch (Exception ex)
            {
                if (ex.Message != "")
                {
                    TbOut.Text = ex.Message;
                }

                TbOut.Text = "Некорректный ввод\n";
            }


        }

        private DynamicStructuresEntities.LinkedList<string> StartTask(int num, List<string> in1, List<string> in2)
        {
            DynamicStructuresEntities.LinkedList<string> result = new DynamicStructuresEntities.LinkedList<string>();
            var array1 = RemoveSpace(in1);
            var List2 = RemoveSpace(in2);
            switch (num)
            {
                case 1:
                    result = new Task1<string>() { }.GetResult(array1);
                    break;

                case 2:
                    result = new Task2<string>() { }.GetResult(array1);
                    break;

                case 3:
                    result.AddLast(new Task3<string>() { }.GetResult(array1).ToString());
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
                    result = Get10TaskResult(array1, List2[0]);
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

        private DynamicStructuresEntities.LinkedList<string> RemoveSpace(List<string> list)
        {
            DynamicStructuresEntities.LinkedList<string> result = new DynamicStructuresEntities.LinkedList<string>();

            foreach (string s in list)
            {
                result.AddLast(s.Replace(" ", ""));
            }

            return result;
        }

        private DynamicStructuresEntities.LinkedList<string> Get10TaskResult(DynamicStructuresEntities.LinkedList<string> array1, string val)
        {
            DynamicStructuresEntities.LinkedList<string> result = new DynamicStructuresEntities.LinkedList<string>();
            var res = new Task10<string>() { }.GetResult(array1, val);
            res.ToList();
            bool fl = true;
            foreach (var r in res)
            {
                foreach (var s in r.ToList)
                {
                    result.AddLast(s);
                }

                if (fl)
                {
                    result.AddLast(" И ");
                    fl = false;
                }
            }


            return result;
        }

        private void Write(List<string> list)
        {
            TbOut.Text += "Результат:\n";

            foreach (var s in list)
            {
                if (s != null && s != "")
                {
                    TbOut.Text += s + " ";
                }
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
                TbOut.Text = "Результат: " + result + "\nRPN:" + rpn;
            }
            catch (Exception ex)
            {
                TbOut.Text = ex.Message;
            }

        }

        private void TaskSelected(object sender, RoutedEventArgs e)
        {

            if (NumberOfTask.Text == "9")
            {
                string path = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.Parent?.ToString() + "\\fileFor9Task.txt";
                string file = "";

                Button btn = new Button();
                btn.Content = "NewButton";
                btn.Width = 100;
                btn.Height = 25;

                try
                {
                    try { file = File.ReadAllText(path); }
                    catch { TbOut.Text = "Файл не найден!"; }

                    var lst = ParseFile(file);
                    Write(StartTask(9, lst[0].ToList(), lst[1].ToList()).ToList);
                }

                catch (Exception ex)
                {
                    TbOut.Text = ex.Message + "\r\n"; ;
                }
            }
        }

        private string[][] ParseFile(string file)
        {
            List<string[]> resultLines = new List<string[]>();
            try
            {
                if (file == null)
                {
                    throw new Exception("Файл не может быть пустым");
                }
                string[] lines = file.Split("\n");
                foreach (string line in lines)
                {
                    if (line != "\n" && line !="\r")
                    {
                        resultLines.Add(line.Split(' ', ',', ';', '\r','\n'));
                    }

                }
                return resultLines.ToArray();

            }


            catch 
            {
                throw new Exception("Произошла ошибка при обработке файла.\nПроверьте правильность ввода.\nКаждый список должен начинаться с новой строки/\nКаждый элемент" +
                    " списка - через пробел/запятую/точку с запятой.");
    }

}

private void TextBlock_KeyDown(object sender, KeyEventArgs e)
{

}

        private void TbOut_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
