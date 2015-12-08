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
using applepong.ViewModel;


namespace applepong.View {
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
            VM.Input(sender, e);
        }

        private void JoinButton_OnClick(object sender, RoutedEventArgs e) {
            VM.Start();
        }

        //Networking stuff for later on:

        private void Client(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.mode = 1;
                VM.GameReset();
            }
        }

        private void Server(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.mode = 2;
                VM.GameReset();
            }
        }

        //Clears text box
        private void RemoteAddress_OnGotFocus(object sender, RoutedEventArgs e) {
            TextBox address = (TextBox) sender;
            address.Text = String.Empty;
            address.GotFocus -= RemoteAddress_OnGotFocus;

        }


        private void SetLocal(object sender, RoutedEventArgs e) {
            if (VM != null) {
                VM.mode = 0;
                VM.GameReset();
            }
        }


        //Touch Controls
        // 1 = LeftUp
        // 2 = LeftDown
        // 3 = RightUp
        // 4 = RightDown
        private void LeftUp_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if ((VM.mode == 0) || (VM.mode == 1)) {
                    VM.TouchPaddle(1);
                }
            }
        }

        private void LeftDown_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if ((VM.mode == 0) || (VM.mode == 1)) {
                    VM.TouchPaddle(2);
                }
            }
        }

        private void RightUp_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if ((VM.mode == 0) || (VM.mode == 2)) {
                    VM.TouchPaddle(3);
                }
            }
        }

        private void RightDown_OnClickButton_OnClick(object sender, RoutedEventArgs e) {
            if (VM != null) {
                if ((VM.mode == 0) || (VM.mode == 2)) {
                    VM.TouchPaddle(4);
                }
            }
        }


        private void ResetButton_OnClick(object sender, RoutedEventArgs e) {
            VM.GameReset();
        }

        private void Help_OnClick(object sender, RoutedEventArgs e) {
            MessageBox.Show("No", "Apple Pong - Help", MessageBoxButton.OK);
        }
    }
}
