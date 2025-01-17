﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;

namespace TravelListApp.Command
{
    class AddCategoriesToTravelCommand : ICommand
    {
        private AddCategoriesToTravelViewModel _viewmodel;
        public AddCategoriesToTravelCommand(AddCategoriesToTravelViewModel viewmodel)
        {
            _viewmodel = viewmodel;
        }

        public event EventHandler CanExecuteChanged;
        public bool execute = true;

        public bool CanExecute(object parameter)
        { 
            return execute;
        }

        public void Execute(object parameter)
        {
            execute = false;
            _viewmodel.AddCategories();
        }

    }
}
