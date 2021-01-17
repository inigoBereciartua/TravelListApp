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
using TravelListApp.ViewModel;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CategoryDetails : Page
    {
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
            var vm = (CategoryDetailsViewModel)this.DataContext;
            vm.Category = (Category)e.Parameter;
            vm.LoadData();
            base.OnNavigatedTo(e);
        }

        private async void DeleteItem_Click(object sender, RoutedEventArgs e)
        {

            var item = (sender as AppBarButton).DataContext;
            var vm = (CategoryDetailsViewModel)this.DataContext;
            vm.RemoveItem((Item)item);
        }

        private async void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            var task = (sender as AppBarButton).DataContext;
            var vm = (CategoryDetailsViewModel)this.DataContext;
            vm.RemoveTask((Model.Task)task);
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Categories));
        }
    }
}
