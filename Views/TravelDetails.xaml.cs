using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelListApp.Command;
using TravelListApp.Model;
using TravelListApp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
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
    public sealed partial class TravelDetails : Page
    {
        public ObservableCollection<Item> ItemsCollection { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Category> CategoriesCollection { get; set; } = new ObservableCollection<Category>();
        public ObservableCollection<Task> TasksCollection { get; set; } = new ObservableCollection<Task>();
        Travel Travel { get; set; }
        public TravelDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Call to backend to get items, to get categories and tasks
            this.Travel = (Travel)e.Parameter;
            foreach (var item in Travel.Items)
            {
                ItemsCollection.Add(item);
            }
            ItemsList.ItemsSource = ItemsCollection;
            foreach(var category in Travel.Categories)
            {
                CategoriesCollection.Add(category);
            }
            CategoriesList.ItemsSource = CategoriesCollection;
            foreach (var task in Travel.Tasks)
            {
                TasksCollection.Add(task);
            }
            TasksList.ItemsSource = TasksCollection;
            base.OnNavigatedTo(e);
        }

          private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Travels));
        }

        private async void AddItems_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddItemsToTravel), this.Travel);
        }
        private async void AddTasks_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                //bool res = await vm.RemoveItem(Travel,(Item)item);
                //TODO: Call to the backend to remove the item from a travel
            }
        }
        private void AddCategories_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AddCategoriesToTravel), this.Travel);
        }  
        private async void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                bool res = await vm.RemoveTaskAsync(Travel,(Task)item);
                if (res)
                {
                    Travel.Tasks.Remove((Task)item);
                    TasksCollection.Remove((Task)item);
                }
            }
        }
        private async void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                bool res = await vm.RemoveCategoryAsync(Travel,(Category)item);
                if (res)
                {
                    Travel.Categories.Remove((Category)item);
                    CategoriesCollection.Remove((Category)item);
                }
            }
        }
        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                bool res =  await vm.RemoveItemAsync(Travel,(Item)item);
                if (res)
                {
                    Travel.Items.Remove((Item)item);
                    ItemsCollection.Remove((Item)item);
                }
                //TODO: Call to the backend to remove the item from a travel
            }
        }
        private async void CheckTask_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Task t = (Task)item;
                var vm = (TravelDetailsViewModel)this.DataContext;
                bool res = await vm.CheckTaskAsync(Travel, t);
                if (res)
                {
                    
                    if (t.Checked)
                    {
                        AppBarButton bt = (AppBarButton)sender;
                        bt.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    }
                    else
                    {
                        AppBarButton bt = (AppBarButton)sender;
                        bt.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }

                }
            }
        }
        private async void CheckItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Item t = (Item)item;
                var vm = (TravelDetailsViewModel)this.DataContext;
                bool res = await vm.CheckItemAsync(Travel, t);
                if (res)
                {
                    if (t.Check)
                    {
                        AppBarButton bt = (AppBarButton)sender;
                        bt.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    }
                    else
                    {
                        AppBarButton bt = (AppBarButton)sender;
                        bt.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                    }
                }
                //TODO: Call to the backend to remove the item from a travel
            }
        }

    }
}
