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
using System.Windows.Controls;
using System.Windows;
using System.IO;
using Path = System.IO.Path;

namespace TextProcessorApp
{
    public partial class MainWindow : Window
    {
        private TextEditor _textEditor;

        public MainWindow()
        {
            InitializeComponent();
            _textEditor = new TextEditor(textBox);
            this.KeyDown += MainWindow_KeyDown; // Обработка сочетаний клавиш
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            _textEditor.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            _textEditor.Redo();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fileNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите имя файла.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = System.IO.Path.Combine(currentDirectory, fileNameTextBox.Text);

            if (!System.IO.Path.HasExtension(filePath))
            {
                filePath += ".txt";
            }

            try
            {
                _textEditor.SaveToFile(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
            {
                if (e.Key == Key.Z && (Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                {
                    _textEditor.Redo();
                    e.Handled = true;
                }
                else if (e.Key == Key.Z)
                {
                    _textEditor.Undo();
                    e.Handled = true;
                }
            }
        }
    }
}
