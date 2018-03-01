using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace CorsoEnaip2018_Tasks_WPF2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CalculateMaxPrime_Click(object sender, RoutedEventArgs e)
        {
            Spinner.IsBusy = true;

            var upperLimit = Input.Text;

            Result.Text = "Calculating...";

            Debug.WriteLine($"On Button Click handler Thread is: {Thread.CurrentThread.ManagedThreadId}");

            // quando uso Task.Run passando una Func<T> come parametro,
            // Task.Run restituisce un Task<T>.
            var task = Task.Run(() =>
            {
                Debug.WriteLine(
                    $"On Prime Number execution Thread is: " +
                    $"{Thread.CurrentThread.ManagedThreadId}");
                return PrimeFinder.FindMaxPrimeUnder(upperLimit);
            });
            // su questo Task posso fare 'await'
            // e mi viene restituito un oggetto di tipo T.
            try
            {
                var maxPrime = await task;
                Result.Text = maxPrime.ToString();
            }
            catch
            {
                Result.Text = "Errore! Input non corretto!";
            }
            finally
            {
                Spinner.IsBusy = false;
            }

            Thread.Sleep(1000);

            Debug.WriteLine(
                $"On Button Click handler after Prime calculation" +
                $" Thread is: {Thread.CurrentThread.ManagedThreadId}");
        }
    }

    class PrimeFinder
    {
        public static int FindMaxPrimeUnder(string upperLimitString)
        {
            //Thread.Sleep(500);

            int upperLimit = int.Parse(upperLimitString);

            int max = 2;

            for(int i = 2; i <= upperLimit; i++)
            {
                bool isPrime = true;

                for(int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    max = i;
            }

            return max;
        }
    }
}
