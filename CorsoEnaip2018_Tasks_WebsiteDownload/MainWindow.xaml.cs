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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
    }
}
