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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Collections.Concurrent;

namespace BankQueueSystem
{
    public partial class MainWindow : Window
    {
        private ConcurrentQueue<(string ClientName, string Service, int Time)> 
            _queue = new ConcurrentQueue<(string ClientName, string Service, int Time)>();
        private List<ProgressBar> _bankersProgressBars = new List<ProgressBar>();
        private List<bool> _bankersAvailability = new List<bool>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            string clientName = ClientNameTextBox.Text;
            if (string.IsNullOrWhiteSpace(clientName))
            {
                MessageBox.Show("Please enter a client name.");
                return;
            }

            if (ServiceComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a service.");
                return;
            }

            string service = (ServiceComboBox.SelectedItem as ComboBoxItem).Content.ToString();
            int time = int.Parse((ServiceComboBox.SelectedItem as ComboBoxItem).Tag.ToString());

            _queue.Enqueue((clientName, service, time));
            QueueListBox.Items.Add($"{clientName} - {service}");
        }

        private void SetBankers_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(NumberOfBankersTextBox.Text, out int numberOfBankers))
            {
                _bankersProgressBars.Clear();
                _bankersAvailability.Clear();
                BankersItemsControl.Items.Clear();

                for (int i = 0; i < numberOfBankers; i++)
                {
                    ProgressBar progressBar = new ProgressBar { Maximum = 100, Value = 0,
                        Height = 20, Margin = new Thickness(0, 5, 0, 5) };
                    _bankersProgressBars.Add(progressBar);
                    _bankersAvailability.Add(true); // Bankers are initially available
                    BankersItemsControl.Items.Add(progressBar);
                }

                Task.Run(() => ProcessQueue());
            }
            else
            {
                MessageBox.Show("Please enter a valid number of bankers.");
            }
        }

        private async Task ProcessQueue()
        {
            while (true) // Run continuously to handle incoming clients
            {
                if (_queue.TryDequeue(out var client))
                {
                    // Wait until a banker becomes available
                    int availableBankerIndex = -1;
                    while (availableBankerIndex == -1)
                    {
                        availableBankerIndex = _bankersAvailability.FindIndex(isAvailable => isAvailable);
                        if (availableBankerIndex == -1) await Task.Delay(500); 
                    }

                    // Assign the client to the available banker
                    _bankersAvailability[availableBankerIndex] = false;
                    var progressBar = _bankersProgressBars[availableBankerIndex];
                    _ = ServeClient(client, progressBar, availableBankerIndex);
                }
                else
                {
                    await Task.Delay(500); // Delay if queue is empty
                }
            }
        }

        private async Task ServeClient((string ClientName, string Service, int Time)
            client, ProgressBar progressBar, int bankerIndex)
        {
            // Remove client from the list as they're now being served
            Application.Current.Dispatcher.Invoke(() =>
            {
                QueueListBox.Items.Remove($"{client.ClientName} - {client.Service}");
            });

            int steps = 10;
            int delay = client.Time * 1000 / steps;

            for (int i = 0; i <= steps; i++)
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    progressBar.Value = (i / (double)steps) * 100;
                });
                await Task.Delay(delay);
            }

            Application.Current.Dispatcher.Invoke(() =>
            {
                progressBar.Value = 0;
                _bankersAvailability[bankerIndex] = true; // Banker becomes available again
            });
        }
    }
}
