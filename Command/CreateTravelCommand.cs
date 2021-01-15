using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class CreateTravelCommand : ICommand
    {
        private TravelsViewModel _viewmodel;
        public CreateTravelCommand(TravelsViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewmodel.CreateTravel();
        }
    }
}
