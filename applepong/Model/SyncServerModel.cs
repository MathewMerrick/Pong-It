using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Controls;

namespace applepong.Model {

    public class SynchronousSocketListener : INotifyPropertyChanged {

        private string data;
        private Socket handler;
        private byte[] bytes;
        private int _yPaddle;

        public void StartListening() {
            bytes = new Byte[1024];
            
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

                listener.Bind(localEndPoint);
                listener.Listen(10);
                handler = listener.Accept();
                data = null;
                
        }

        public void Send(int yPaddle, double xBall, double yBall, int leftScore, int rightScore) {
            string send = (yPaddle.ToString() + ',' + xBall.ToString() + ',' + yBall.ToString() + ',' + leftScore.ToString() + ',' +rightScore.ToString() + ';');

            byte[] msg = Encoding.ASCII.GetBytes(send);
            handler.Send(msg);

            data = "";
            // An incoming connection needs to be processed.
            while (true) {
                bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);
                data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (data.IndexOf(";") > -1) {
                    break;
                }
            }

            data = data.Replace(";", "");
            _yPaddle = Int32.Parse(data);
        }

        public void StopServer() {
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        public int yPaddle {
            get { return _yPaddle; }
            set {
                _yPaddle = value;
                OnPropertyChanged("yPaddle");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
