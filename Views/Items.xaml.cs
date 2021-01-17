using System;
using System.Collections.Generic;
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
using System.Collections.ObjectModel;
using TravelListApp.ViewModel;


// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Items : Page
    {
        public ObservableCollection<Item> itemsList { get; set; } = new ObservableCollection<Item>();
        public Items()
        {
            this.InitializeComponent();
        }

        private void AppBarButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            var vm = (ItemsViewModel)this.DataContext;
            vm.RemoveItem((Item)item);
        }
    }
}
