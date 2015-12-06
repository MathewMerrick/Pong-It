using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace pongit.Model{

    class Paddle : INotifyPropertyChanged {
        private int _y;

        public int y {
            get { return _y; }
            set {
                _y = value;
                OnPropertyChanged("y");
            }
        }
        #region INotifyPropertyChanged PaddleMember
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
