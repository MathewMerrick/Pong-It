using System.ComponentModel;

namespace applepong.Model {

    class Score : INotifyPropertyChanged {
        private int _left;
        private int _right;

        public int left {
            get { return _left; }
            set {
                _left = value;
                OnPropertyChanged("left");
            }
        }
        public int right {
            get { return _right; }
            set {
                _right = value;
                OnPropertyChanged("right");
            }
        }

        #region INotifyPropertyChanged ScoreMember
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
