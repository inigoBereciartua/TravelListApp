using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelListApp.Model;
using TravelListApp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddCategoriesToTravel : Page
    {
        public Travel Travel;
        public ObservableCollection<Category> CategoriesOfTravel { get; set; } = new ObservableCollection<Category>();
        public AddCategoriesToTravel()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var vm = (AddCategoriesToTravelViewModel)this.DataContext;
            vm.Travel = (Travel)e.Parameter;
            vm.LoadData();
            base.OnNavigatedTo(e);
        }

        private void BackArrowButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(TravelDetails), this.Travel);
        }

        private void AppBarButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            var vm = (AddCategoriesToTravelViewModel)this.DataContext;
            //vm.RemoveItem((Item)item);
        }
    }
}
