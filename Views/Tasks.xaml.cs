using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelListApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Tasks : Page
    {
        public ObservableCollection<Task> TasksCollection { get; set; } = new ObservableCollection<Task>();
        public Tasks()
        {
            this.InitializeComponent();
            TasksList.ItemsSource = TasksCollection;
        }

        private void CreateTask_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            if (NewTaskName.Text == "")
            {
                ErrorText.Text = "Task's name can't be empty";
            }
            else if (NameOfTaskIsInUse(NewTaskName.Text))
            {
                ErrorText.Text = "That task name is already in use";
            }
            else
            {
                TasksCollection.Add(new Task { Description = NewTaskName.Text });
                //TODO: Call backend to create Item
            }
        }

        private bool NameOfTaskIsInUse(string text)
        {
            foreach(var task in TasksCollection)
            {
                if(task.Description == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void TasksList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var task = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteTaskDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                TasksCollection.Remove((Task)task);
                //TODO: Call backend to delete Task
            }
        }
    }
}
