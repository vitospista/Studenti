using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CorsoEnaip2018_Threads_WPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            DispatcherUnhandledException += (s, ee) =>
            {
                MessageBox.Show(
                    "La app ha catturato l'eccezione: "
                    + ee.Exception.Message);
            };

            base.OnStartup(e);
        }
    }
}
