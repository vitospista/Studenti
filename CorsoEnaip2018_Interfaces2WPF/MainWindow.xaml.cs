using CorsoEnaip2018_Interfaces2Library;
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

namespace CorsoEnaip2018_Interfaces2WPF
{
    public partial class MainWindow : Window, ICompleteNameListener
    {
        public MainWindow()
        {
            InitializeComponent();

            var p = new Person(this);

            DataContext = p;
        }

        public void SetNewCompleteName(string completeName)
        {
            CompletNameTextBox.Text = completeName;
        }
    }
}
