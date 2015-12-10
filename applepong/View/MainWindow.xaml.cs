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
            MessageBox.Show("Apple Pong version derived from the famous game Pong!\n" +
                            "Group Members: Mathew Merrick, Jomar Dimaculangan, Josh Meyer, Michael Garten.\n\n" +
                            "How to play: Cougars can move their paddles by pressing the up and down keys and Huskies can move theirs by pressing W and S.\n\n" +
                            "Objective: Players use the paddles to hit a ball back and forth to gain points. First to eleven points win.\n\n" +
                            "Networking: Host, press the host radio button then start. Wait for clients to connect. " +
                            "Client, press the join radio button and enter the host's IP address. Then press start\n\n" +
                            "Current network implementation is synchronous. May experience increased latency between host and client " +
                            "when the response time is greater. \n\n" +
                            "Asynchronous implementation still needs testing. Planned for a future release, specifically, after finals week.", "Apple Pong - Help", MessageBoxButton.OK);
        }
    }
}
