using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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

namespace CorsoEnaip2018_Tasks_WebsiteDownload_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadFastestButton_Click(object sender, RoutedEventArgs e)
        {
            var textBoxes = new[] { TB1, TB2, TB3 };

            var tasks = textBoxes
                .Select(x => new HttpClient().GetAsync(x.Text))
                .ToList();

            var resultTask = await Task.WhenAny(tasks);

            var fastest = tasks.IndexOf(resultTask);
            var fastestTB = textBoxes[fastest];

            var result = await resultTask;

            var content = await result.Content.ReadAsStringAsync();

            var finalMessage =
                $"Fastest URL: {fastestTB.Text};" +
                Environment.NewLine +
                $"Length: {content.Length} chars";

            ResultTB.Text = finalMessage;
        }

        private async void LoadAllButton_Click(object sender, RoutedEventArgs e)
        {
            var textBoxes = new[] { TB1, TB2, TB3 };

            var tasks = textBoxes
                .Select(x => new HttpClient().GetAsync(x.Text))
                .ToList();

            var responseMessages = await Task.WhenAll(tasks);

            var finalMessage = "";

            for(int i = 0; i < responseMessages.Length; i++)
            {
                var url = textBoxes[i].Text;
                var result =
                    await responseMessages[i].Content.ReadAsStringAsync();

                finalMessage += $"URL: {url}; length: {result.Length};{Environment.NewLine}";
            }

            ResultTB.Text = finalMessage;
        }
    }
}
