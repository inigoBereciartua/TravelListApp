using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelListApp.Model;

namespace TravelListApp.ViewModel
{
    class TravelDetailsViewModel: INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
       /* public Travel Travel
        {
            get { return _travel; }
            set {

                if (value != _travel)
                {
                    _travel = value;
                    NotifyPropertyChanged("Travel");
                }

            }
        }*/

        public TravelDetailsViewModel()
        {

        }
    }
}
