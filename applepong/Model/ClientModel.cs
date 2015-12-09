using System;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace applepong.Model {
    public class SynchronousSocketClient : INotifyPropertyChanged {


        private Socket sender = new Socket(AddressFamily.InterNetwork,SocketType.Stream, ProtocolType.Tcp);
        private IPEndPoint remoteEP;
        private byte[] bytes;

        private int _yPaddle;
        private double _xBall;
        private double _yBall;
        private int _leftScore;
        private int _rightScore;

        public void StartClient(string userAddress) {

            bytes = new byte[1024];


            IPAddress ipAddress = IPAddress.Parse(userAddress);

            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());

            remoteEP = new IPEndPoint(ipAddress, 11000);
            sender.Connect(remoteEP);
        }

        public void Send(string yPaddle) {

            yPaddle = yPaddle + ";";
            byte[] msg = Encoding.ASCII.GetBytes(yPaddle);

            // Send the data through the socket.
            int bytesSent = sender.Send(msg);
            int bytesRec = sender.Receive(bytes);
            string received = Encoding.ASCII.GetString(bytes, 0, bytesRec);

            received = received.Replace(";", "");
            string[] coordinates = received.Split(',');

            _yPaddle = Int32.Parse(coordinates[0]);
            _xBall = Double.Parse(coordinates[1]);
            _yBall = Double.Parse(coordinates[2]);
            _leftScore = Int32.Parse(coordinates[3]);
            _rightScore = Int32.Parse(coordinates[4]);
            
        }


        public int yPaddle {
            get { return _yPaddle; }
            set {
                _yPaddle = value;
                OnPropertyChanged("yPaddle");
            }
        }

        public double yBall {
            get { return _yBall; }
            set {
                _yBall = value;
                OnPropertyChanged("xPaddle");
            }
        }

        public double xBall {
            get { return _xBall; }
            set {
                _xBall = value;
                OnPropertyChanged("xBall");
            }
        }

        public int leftScore {
            get { return _leftScore; }
            set {
                _leftScore = value;
                OnPropertyChanged("xBall");
            }
        }

        public int rightScore {
            get { return _rightScore; }
            set {
                _rightScore = value;
                OnPropertyChanged("xBall");
            }
        }




        public void Receive(int yPaddle, double xBall, double yBall) {
            _yPaddle = yPaddle;
            _xBall = xBall;
            _yBall = yBall;
        }


        public void StopClient() {
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
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