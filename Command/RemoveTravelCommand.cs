using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.Model;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class RemoveTravelCommand : ICommand
    {
        private TravelsViewModel _viewmodel;
        public RemoveTravelCommand(TravelsViewModel viewModel)
        {
            _viewmodel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewmodel.RemoveTravel((Travel)parameter);
        }
    }
}
