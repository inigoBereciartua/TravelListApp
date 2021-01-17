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
            //TODO: Call to backend to get items
            foreach (var item in ItemsManager.GetItems())
            {
                itemsList.Add(item);
            }
            ItemsList.ItemsSource = itemsList;
        }

        private void ItemsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var item = (Item)e.ClickedItem;
        }

        private async void AppBarButton_ClickAsync(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if(result == ContentDialogResult.Primary)
            {
                var vm = (ItemsViewModel)this.DataContext;
                vm.RemoveItem((Item)item);
            }
        }
        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            if (NewItemName.Text == "")
            {
                ErrorText.Text = "Item's name can't be empty";
            }else if (NameOfItemIsInUse(NewItemName.Text))
            {
                ErrorText.Text = "That item name is already in use";
            }
            else
            {                
                //TODO: Call backend to create Item
            }
        }

        private bool NameOfItemIsInUse(string text)
        {
            foreach(var item in itemsList)
            {
                if (item.Name == text)
                {
                    return true;
                }
            }
            return false;
        }

        private void deleteItemDialog_Opened(ContentDialog sender, ContentDialogOpenedEventArgs args)
        {

        }
    }
}
