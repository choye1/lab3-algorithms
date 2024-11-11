using PersonСontactsApp;
using System.Collections.ObjectModel;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PersonContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ContactViewModel();
        }
    }

    public class ContactViewModel : INotifyPropertyChanged
    {
        private ContactList contactList;
        private ObservableCollection<Person> persons;
        private Person selectedPerson;

        public ContactViewModel()
        {
            contactList = new ContactList();
            persons = new ObservableCollection<Person>();
            AddPersonCommand = new RelayCommand(AddPerson);
            RemovePersonCommand = new RelayCommand(RemovePerson, CanRemovePerson);
            SortByNameCommand = new RelayCommand(SortByName);
            SortBySurnameCommand = new RelayCommand(SortBySurname);
            SortByNameAndSurnameCommand = new RelayCommand(SortByNameAndSurname);
        }

        public ObservableCollection<Person> Persons
        {
            get { return persons; }
            set
            {
                persons = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get { return selectedPerson; }
            set
            {
                selectedPerson = value;
                OnPropertyChanged();
                ((RelayCommand)RemovePersonCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand AddPersonCommand { get; }
        public ICommand RemovePersonCommand { get; }
        public ICommand SortByNameCommand { get; }
        public ICommand SortBySurnameCommand { get; }
        public ICommand SortByNameAndSurnameCommand { get; }

        private void AddPerson()
        {
            var addContactWindow = new AddContactWindow();
            if (addContactWindow.ShowDialog() == true)
            {
                try
                {
                    Person newPerson = new Person(addContactWindow.Name, addContactWindow.Surname, addContactWindow.PhoneNumber);
                    contactList.AddPerson(newPerson);
                    Persons.Add(newPerson);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding contact: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void RemovePerson()
        {
            if (SelectedPerson != null)
            {
                contactList.RemovePerson(SelectedPerson);
                Persons.Remove(SelectedPerson);
            }
        }

        private bool CanRemovePerson()
        {
            return SelectedPerson != null;
        }

        private void SortByName()
        {
            Persons = new ObservableCollection<Person>(contactList.SortByName());
        }

        private void SortBySurname()
        {
            Persons = new ObservableCollection<Person>(contactList.SortBySurName());
        }

        private void SortByNameAndSurname()
        {
            Persons = new ObservableCollection<Person>(contactList.SortByNameAndSurname());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}