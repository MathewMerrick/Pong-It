using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace applepong.Model {
    
    class Ball : INotifyPropertyChanged {
        private double _x;
        private double _y;
        private bool _goingRight;


        public double x {
            get { return _x; }
            set{
                _x = value;
                OnPropertyChanged("x");
            }
        }

        public double y {
            get { return _y; }
            set {
                _y = value;
                OnPropertyChanged("y");
            }
        }

        public bool GoingRight {
            get { return _goingRight; }
            set {
                _goingRight = value;
                OnPropertyChanged("GoingRight");
            }
        }

        #region INotifyPropertyChanged BallMember
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

    }
}
