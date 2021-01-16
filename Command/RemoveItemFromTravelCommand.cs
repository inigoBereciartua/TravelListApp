using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class RemoveItemFromTravelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;


        public RemoveItemFromTravelCommand(TravelDetailsViewModel travelDetailsViewModel)
        {

        }

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
