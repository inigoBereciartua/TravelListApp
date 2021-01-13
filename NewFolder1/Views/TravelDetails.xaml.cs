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

namespace TravelListApp.NewFolder1.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class TravelDetails : Page
    {
        public ObservableCollection<ItemForTravel> ItemsCollection { get; set; } = new ObservableCollection<ItemForTravel>();
        public ObservableCollection<Category> CategoriesCollection { get; set; } = new ObservableCollection<Category>();

        public ObservableCollection<Task> TasksCollection { get; set; } = new ObservableCollection<Task>();
        Travel Travel;
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

        private void ItemsList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddCategories_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            var category = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteCategoryDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                CategoriesCollection.Remove((Category)category);
                Travel.Categories.Remove((Category)category);
                //TODO: Call backend to remove Category from Travel
                //TODO: remove all the items owned by a category, that are not part of another category of the Travel
            }
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                ItemsCollection.Remove((ItemForTravel)item);
                Travel.Items.Remove((ItemForTravel)item);
                //TODO: Call to the backend to remove the item from a travel
            }
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Travels));
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
