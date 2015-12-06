using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using pongit.ViewModel;

namespace pongit {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
            pongit.View.MainWindow window = new pongit.View.MainWindow();
            GameViewModel VM = new GameViewModel();
            window.DataContext = VM;
            window.Show();
        }
    }
}
