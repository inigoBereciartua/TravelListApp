using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelListApp.Model;
using System.Collections.ObjectModel;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.NewFolder1.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CategoryDetails : Page
    {
        public Category category;
        public ObservableCollection<Item> ItemsNotInCategory { get; set; } = new ObservableCollection<Item>();

        public ObservableCollection<Item> ItemsOfCategory { get; set; } = new ObservableCollection<Item>();

        public ObservableCollection<Task> TasksNotInCategory { get; set; } = new ObservableCollection<Task>();
        
        public ObservableCollection<Task> TasksOfCategory { get; set; } = new ObservableCollection<Task>();
        public CategoryDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Call to backend to get items
            var itemsList = ItemsManager.GetItems();
            this.category = (Category)e.Parameter;
            foreach (var item in category.Items)
            {                
                itemsList.Remove(item);

                this.ItemsOfCategory.Add(item);
            }
            ItemsList.ItemsSource = this.ItemsOfCategory;

            foreach(var item in itemsList)
            {
                ItemsNotInCategory.Add(item);
            }

            //TODO: Call to backend to get tasks
            var tasksList = TaskManager.GetTasks();            
            foreach(var task in category.Tasks)
            {
                tasksList.Remove((Task)task);
                this.TasksOfCategory.Add((Task)task);
            }
            TasksList.ItemsSource = TasksOfCategory;

            foreach(var task in tasksList)
            {
                TasksNotInCategory.Add(task);
            }
            base.OnNavigatedTo(e);
        }

        private void ItemsList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
        

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextItems.Text = "";
            ErrorTextTasks.Text = "";
            if (ItemsNotInCategoryComboBox.SelectedIndex < 0)
            {
                ErrorTextItems.Text = "No item selected";
            }
            else
            {
                Item selectedItem = (Item)ItemsNotInCategoryComboBox.SelectedItem;                
                ItemsNotInCategory.Remove(selectedItem);
                ItemsOfCategory.Add(selectedItem);
                //TODO: Call backend to add item to category
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextItems.Text = "";
            ErrorTextTasks.Text = "";
            if (TasksNotInCategoryComboBox.SelectedIndex < 0)
            {
                ErrorTextTasks.Text = "No task selected";
            }
            else
            {
                Task selectedTask = (Task)TasksNotInCategoryComboBox.SelectedItem;
                TasksNotInCategory.Remove(selectedTask);
                TasksOfCategory.Add(selectedTask);
                //TODO: Call backend to add task to category
            }
        }

        private void TasksList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Item removedItem = (Item)item;
                ItemsOfCategory.Remove(removedItem);
                ItemsNotInCategory.Add(removedItem);
                //TODO: Call backend to delete Item
            }
        }

        private async void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var task = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Task removedTask = (Task)task;
                TasksOfCategory.Remove(removedTask);
                TasksNotInCategory.Add(removedTask);
                //TODO: Call backend to delete Item
            }
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Categories));
        }
    }
}
