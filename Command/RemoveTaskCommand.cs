using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TravelListApp.ViewModel;
using TravelListApp.Model;

namespace TravelListApp.Command
{
    class RemoveTaskCommand : ICommand
    {
        private TasksViewModel _viewmodel;
        public RemoveTaskCommand(TasksViewModel viewmodel)
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
            Model.Task task = (Model.Task)parameter;
            _viewmodel.RemoveTask(task);
        }
    }
}
