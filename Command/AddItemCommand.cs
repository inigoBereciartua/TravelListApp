using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class AddItemCommand : ICommand
    {
        private AddItemsToTravelViewModel _viewmodel;
        public AddItemCommand(AddItemsToTravelViewModel viewmodel)
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
            _viewmodel.AddItems();
        }
    }
}
