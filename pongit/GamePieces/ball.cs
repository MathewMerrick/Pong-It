using System.ComponentModel;

namespace pongit
{
    class Ball : INotifyPropertyChanged
    {
        private double xVar;
        private double yVar;
        private int left;
        private int right;
        public event PropertyChangedEventHandler PropertyChanged;


        public double X{
            get{
                return xVar;
            }
            set{
                xVar = value;
                OnPropertyChanged("X");
                
                
            }
        }

        public double Y{
            get{
                return yVar;
            }
            set{
                yVar = value;
                OnPropertyChanged("Y");
            }
        }

        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

    }
}
