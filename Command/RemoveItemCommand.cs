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
    class RemoveItemCommand : ICommand
    {
        private ItemsViewModel _viewModel;

        public RemoveItemCommand(ItemsViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            Item selectedItem = (Item)parameter;
            _viewModel.RemoveItem(selectedItem);
        }
    }
}
