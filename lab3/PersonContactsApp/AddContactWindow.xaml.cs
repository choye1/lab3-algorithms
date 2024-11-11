using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PersonContactsApp
{
    public partial class AddContactWindow : Window
    {
        public AddContactWindow()
        {
            InitializeComponent();
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public long PhoneNumber { get; private set; }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Name = NameTextBox.Text;
            Surname = SurnameTextBox.Text;
            if (long.TryParse(PhoneNumberTextBox.Text, out long phoneNumber))
            {
                PhoneNumber = phoneNumber;
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Invalid phone number", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
