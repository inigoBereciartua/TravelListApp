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
        public ObservableCollection<Category> CategoriesCollection { get; set; } = new ObservableCollection<Category>();
        Travel Travel { get; set; }
        Category SelectedCategory { get; set; }
        public TravelDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.Travel = (Travel)e.Parameter;
            //TODO: Call to backend to get items, to get categories and tasks
            var vm = (TravelDetailsViewModel)this.DataContext;
            vm.Travel = (Travel)e.Parameter;
            vm.LoadData();
            base.OnNavigatedTo(e);
        }
        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Travels));
        }
        private async void AddItems_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await addItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {                
                var vm = (TravelDetailsViewModel)this.DataContext;
                var error = await vm.AddItemAsync();
                if(error != "")
                {
                    showError(error);
                }
            }
        }
        private async void AddTasks_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await addTaskDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                var error = await vm.AddTaskAsync();
                if(error != "")
                {
                    showError(error);
                }
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
                vm.RemoveTaskAsync((Task)item);                
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
                vm.RemoveItemAsync((Item)item);
            }
            
        }
        private void CheckTask_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as CheckBox).DataContext;            
            Task t = (Task)item;
            var vm = (TravelDetailsViewModel)this.DataContext;
            vm.CheckTaskAsync(t);                                                                           
        }
        private void CheckItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as CheckBox).DataContext;           
            Item t = (Item)item;
            var vm = (TravelDetailsViewModel)this.DataContext;
            vm.CheckItemAsync(t);
        }

        private async void DeleteActivity_Click(object sender, RoutedEventArgs e)
        {
            Activity activity = (Activity)(sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteActivityDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                vm.RemoveActivityAsync(activity);
            }
        }
        
        private async void showError(string text)
        {
            errorMessage.Text = text;
            await errorsDialog.ShowAsync();
        }

        private async void AddActivity_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult result = await addActivityDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                var vm = (TravelDetailsViewModel)this.DataContext;
                var error = await vm.AddActivity();
                if(error != "")
                {
                    showError(error);
                }
            }
        }
    }
}
