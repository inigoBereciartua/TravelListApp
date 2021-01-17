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
    class NavigateToCategoryCommand : ICommand
    {
        CategoriesViewModel _viewmodel;
        public NavigateToCategoryCommand(CategoriesViewModel viewModel)
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
            Category category = (Category)parameter;
            _viewmodel.RemoveCategoryAsync(category);
        }
    }
}
