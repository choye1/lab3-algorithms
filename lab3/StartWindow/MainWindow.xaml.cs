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
using BankQueueSystem;
using lab3;
using ListDynamicStructures;
using Loggers;
using OrganizationApp;
using part4;
using PersonContactsApp;
using DynamicStructuresEntities;
using RPNEntities;
using StackHandlers;
using TextProcessorApp;

namespace StartWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            lab3.MainWindow win = new lab3.MainWindow();
            win.Show();
        }

        private void Part4(object sender, RoutedEventArgs e)
        {
            WindowForTasks win = new WindowForTasks();
            win.Show();
        }
        private void Stack(object sender, RoutedEventArgs e)
        {
            TextProcessorApp.MainWindow win = new TextProcessorApp.MainWindow();
            win.Show();
        }
        private void Queue(object sender, RoutedEventArgs e)
        {
            BankQueueSystem.MainWindow win = new BankQueueSystem.MainWindow();
            win.Show();
        }
        private void Three(object sender, RoutedEventArgs e)
        {
            OrganizationApp.MainWindow win = new OrganizationApp.MainWindow();
            win.Show();
        }
        private void List(object sender, RoutedEventArgs e)
        {
            PersonContactsApp.MainWindow win = new PersonContactsApp.MainWindow();
            win.Show();
        }
    }
}