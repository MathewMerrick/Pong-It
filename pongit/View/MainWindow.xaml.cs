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
using System.ComponentModel;
using System.Linq.Expressions;
using pongit.ViewModel;


namespace pongit.View {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private GameViewModel VM;
        
        public MainWindow() {
            InitializeComponent();
            VM = new GameViewModel();
            this.DataContext = VM;
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e) {
            VM.input(sender, e);
        }

        private void JoinButton_OnClick(object sender, RoutedEventArgs e) {
            VM.start();
        }

        //Networking stuff for later on:

        private void Client(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.IsLocal = false;
            }
            //throw new NotImplementedException();
        }

        private void Server(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.IsLocal = false;
            }

            //throw new NotImplementedException();
        }

        //Clears text box
        private void RemoteAddress_OnGotFocus(object sender, RoutedEventArgs e) {
            TextBox address = (TextBox) sender;
            address.Text = String.Empty;
            address.GotFocus -= RemoteAddress_OnGotFocus;

        }


        private void SetLocal(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.IsLocal = true;
            }
        }


        //Touch Controls
        // 1 = LeftUp
        // 2 = LeftDown
        // 3 = RightUp
        // 4 = RightDown
        private void LeftUp_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if (VM.IsLocal == true) {
                    VM.TouchPaddle(1);
                }
            }
        }

        private void LeftDown_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if (VM.IsLocal == true) {
                    VM.TouchPaddle(2);
                }
            }
        }

        private void RightUp_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.TouchPaddle(3);
            }
        }

        private void RightDown_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.TouchPaddle(4);
            }
        }



    }
}
