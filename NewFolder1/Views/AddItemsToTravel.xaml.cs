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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.NewFolder1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddItemsToTravel : Page
    {
        public Travel Travel;        

        public ObservableCollection<Item> ItemsOfTravel { get; set; } = new ObservableCollection<Item>();
        public AddItemsToTravel()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Call to backend to get all the items
            this.Travel = (Travel)e.Parameter;
            List<Item> itemsList = ItemsManager.GetItems();
            itemsList.ForEach(delegate (Item item)
            {
                if (!Travel.Items.Contains(item))
                {
                    ItemsOfTravel.Add(item);
                }
            });
            ItemsList.ItemsSource = ItemsOfTravel;
            base.OnNavigatedTo(e);
        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {            
            foreach(Item item in ItemsList.SelectedItems.ToArray())
            {                
                ItemsOfTravel.Remove(item);
                //TODO: Add call to the backend to add item to a travel
            }            
        }
    }
}
