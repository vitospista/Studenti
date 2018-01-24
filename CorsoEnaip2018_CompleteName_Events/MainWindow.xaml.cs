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

namespace CorsoEnaip2018_CompleteName_Events
{
    public partial class MainWindow : Window
    {
        /*
         * Quando l'utente cambia Name o Surname,
         * La Label CompleteName deve aggiornarsi concatenandoli,
         * e la Label CharsCount deve aggiornarsi
         *     mostrando il conto totale dei caratteri.
         * 
         * Usare l'evento TextChanged delle TextBox.
         * 
         * CompleteNameLabel.Content = "ciao";
         * 
         */

        public MainWindow()
        {
            InitializeComponent();

            NameTextBox.TextChanged += WriteCompleteName;
            SurnameTextBox.TextChanged += WriteCompleteName;
        }

        public void WriteCompleteName(object sender, TextChangedEventArgs e)
        {
            var completeName = NameTextBox.Text + " " + SurnameTextBox.Text;

            CompleteNameLabel.Content = completeName;
            CharsCountLabel.Content = completeName.Length;
        }
    }
}
