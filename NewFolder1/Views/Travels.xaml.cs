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


namespace TravelListApp.NewFolder1.Views
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
            //TODO: Call to backend to get categories
            foreach (var travel in TravelsManager.GetTravels())
            {
                TravelsList.Add(travel);
            }
            TravelsGridView.ItemsSource = TravelsList;
        }

        private void CreateTravel_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate;
            DateTime endDate;

            ErrorText.Text = "";
            if (NewTravelName.Text == "")
            {
                ErrorText.Text = "Travel's name can't be empty";
            }else if (NameOfCategoryIsInUse(NewTravelName.Text))
            {
                ErrorText.Text = "That travel name is already in use";
            }
            else if (!DateTime.TryParseExact(NewTravelsStartDate.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate))
            {
                ErrorText.Text = "Start date format is not correct, it should be dd/MM/yyyy";
            }
            else if (!DateTime.TryParseExact(NewTravelsEndDate.Text, "d/M/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate))
            {
                ErrorText.Text = "End date format is not correct, it should be a valid dd/MM/yyyy";
            }
            else if(startDate > endDate)
            {
                ErrorText.Text = "Start date can't be greater than end date";
            }
            else
            {
                Travel newTravel = new Travel() { Name = NewTravelName.Text, StartDate = startDate, EndDate = endDate };
                TravelsList.Add(newTravel);
                NewTravelName.Text = "";
                NewTravelsStartDate.Text = "";
                NewTravelsEndDate.Text = "";
                //TODO: Call backend to create Travel
            }


        }

        private bool NameOfCategoryIsInUse(string text)
        {
            foreach (var travel in TravelsList)
            {
                if (travel.Name == text)
                {
                    return true;
                }
            }
            return false;
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
