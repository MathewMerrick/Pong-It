using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace pongit
{
    class Pad : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int yPos
        {
            get 
            {
                return yPos;
            }
            set
            {
                yPos = value;
                OnPropertyChanged("YPosition");
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
