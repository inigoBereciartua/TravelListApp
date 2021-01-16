using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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


namespace TravelListApp.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class Travels : Page
    {

        public ObservableCollection<Travel> TravelsList { get; set; } = new ObservableCollection<Travel>();
        public Travels()
        {
            this.InitializeComponent();                        
        }                

        private void TravelsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var travel = (Travel)e.ClickedItem;
            this.Frame.Navigate(typeof(TravelDetails), travel);
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            var travel = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteTravelDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                TravelsList.Remove((Travel)travel);
                //TODO: Call backend to delete Travel
            }
        }
    }
}
