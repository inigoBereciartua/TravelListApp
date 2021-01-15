using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class CreateItemCommand : ICommand
    {
        private ItemsViewModel _viewmodel;
        public event EventHandler CanExecuteChanged;
        public CreateItemCommand(ItemsViewModel viewModel)
        {
            _viewmodel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewmodel.CreateItem();
        }
    }
}
