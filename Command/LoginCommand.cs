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
    class LoginCommand : ICommand
    {
        private LoginViewModel _viewModel;

        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Frame frame = (Frame)parameter;
         
            var logged = await _viewModel.Login();
            if (logged)
            {
                frame.Navigate(typeof(NavView));
            }
        }
    }
}
