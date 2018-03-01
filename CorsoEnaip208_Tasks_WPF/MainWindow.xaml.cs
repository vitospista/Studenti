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

namespace CorsoEnaip208_Tasks_WPF
{
    public partial class MainWindow : Window
    {
        private Worker _w;

        public MainWindow()
        {
            InitializeComponent();

            _w = new Worker();

            _w.StepDone += (s, e) =>
            {
                PB.Value = e.Percentage;
            };
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await _w.DoWork();

            MessageBox.Show("finito!");
        }
    }

    class Worker
    {
        public event EventHandler<WorkerEventArgs> StepDone;

        // quando marco un metodo con 'async'
        // posso usare al suo interno l'operatore 'await'.
        public async Task DoWork()
        {
            // posso fare 'await' solo su un metodo
            // che restituisca un Task o un Task<T> 
            await Task.Delay(500);

            StepDone?.Invoke(this, new WorkerEventArgs(25));

            await Task.Delay(300);

            StepDone?.Invoke(this, new WorkerEventArgs(50));

            await Task.Delay(700);

            StepDone?.Invoke(this, new WorkerEventArgs(75));

            await Task.Delay(500);

            StepDone?.Invoke(this, new WorkerEventArgs(100));
        }
    }

    class WorkerEventArgs : EventArgs
    {
        public WorkerEventArgs(int percentage)
        {
            Percentage = percentage;
        }

        public int Percentage { get; }
    }
}
