using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;
using TravelListApp.Views;
using Windows.UI.Xaml.Controls;

namespace TravelListApp.Command
{
    class NavigateToTravelDetailCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private TravelsViewModel _travelsViewModel;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Frame frame = (Frame)parameter;
            frame.Navigate(typeof(TravelDetails));
        }
    }
}
