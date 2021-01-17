﻿using System;
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
    public class NavigateToRegisterCommand : ICommand
    {
        public NavigateToRegisterCommand(LoginViewModel viewmodel)
        {
            _viewModel = viewmodel;
        }

        private LoginViewModel _viewModel { get; }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            Frame frame = (Frame)parameter;
            frame.Navigate(typeof(Register));
        }
    }
}
