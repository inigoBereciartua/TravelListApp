﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
   public  class RegisterCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private RegisterViewModel _viewModel;

        public RegisterCommand(RegisterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _viewModel.Register();
        }
    }
}
