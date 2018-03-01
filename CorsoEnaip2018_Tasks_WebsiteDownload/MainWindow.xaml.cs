using System.Net.Http;
using System.Windows;

namespace CorsoEnaip2018_Tasks_WebsiteDownload
{
    /*
     * Due righe:
     * 1) textbox dove l'utente inserisce un URL, e un pulsante "Load"
     * 2) una textbox multilinea "espansa" dove compare il codice HTML
     *     della pagina indicata sopra.
     * Implementare le chiamate asincrone con async/await/Task.
     * Usare la classe HttpClient di C#
     * 
     */
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LoadBtn_Click(object sender, RoutedEventArgs e)
        {
            HTMLContent.Text = "loading...";

            var client = new HttpClient();

            var result = await client.GetAsync(UrlTB.Text);
            var html = await result.Content.ReadAsStringAsync();

            HTMLContent.Text = html;
        }
    }
}
