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

namespace TextProcessorApp
{
    public partial class MainWindow : Window
    {
        private TextEditor _textEditor;

        public MainWindow()
        {
            InitializeComponent();
            _textEditor = new TextEditor(textBox);
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            _textEditor.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            _textEditor.Redo();
        }
    }

}
