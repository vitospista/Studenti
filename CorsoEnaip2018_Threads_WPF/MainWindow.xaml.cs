using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CorsoEnaip2018_Threads_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartThreadsButton_Click(object sender, RoutedEventArgs e)
        {
            var counter = 0;

            CounterLabel.Content = counter;

            var threads = Enumerable
                .Range(1, 5)
                .Select(x => new Thread(() =>
                    {
                        counter++;

                        try
                        {
                            if (counter > 3)
                                throw new Exception("Random Exception");
                        }
                        catch (Exception ex)
                        {
                            //la message box è visualizzata
                            //MessageBox.Show($"Il Thread {Thread.CurrentThread.ManagedThreadId} ha lanciato eccezione: {ex.Message}");
                            // siccome questa eccezione non è più catturata dal Thread corrente,
                            // risale fino all'inizio del programma e fa crashare il programma intero
                            throw;
                        }
                        // il Dispatcher ha una coda di Action da eseguire
                        // con 'Invoke' aggiungo in coda.
                        // le Action sono eseguite tutte sullo stesso Thread,
                        // anche se chiamo 'Invoke' da altri Thread.
                        // per le differenze tra 'Invoke' e 'BeginInvoke' vedere: https://stackoverflow.com/questions/46253657/wpf-dispatcher-thread-freeze-main-window
                        this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            CounterLabel.Content = counter;
                        }));
                    }))
                .ToList();

            try
            {
                foreach (var t in threads)
                    t.Start();
            }
            catch (Exception ex)
            {
                // questo catch non viene mai raggiunto
                // perché le eccezioni sono lanciate su altri Thread
                MessageBox.Show("Thread principale; errore: " + ex.Message);
            }

            foreach (var t in threads)
                t.Join();

            MessageBox.Show("Finito!");
        }
    }
}
