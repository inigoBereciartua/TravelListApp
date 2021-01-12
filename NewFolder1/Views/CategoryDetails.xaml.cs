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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.NewFolder1.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class CategoryDetails : Page
    {
        public Category category;
        public ObservableCollection<Item> ItemsNotInCategory { get; set; } = new ObservableCollection<Item>();

        public ObservableCollection<Item> ItemsOfCategory { get; set; } = new ObservableCollection<Item>();
        
        public CategoryDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //TODO: Call to backend to get items
            var itemList = ItemsManager.GetItems();
            this.category = (Category)e.Parameter;
            foreach (var item in category.Items)
            {                
                itemList.Remove(item);

                this.ItemsOfCategory.Add(item);
            }
            ItemsList.ItemsSource = this.ItemsOfCategory;

            foreach(var item in itemList)
            {
                ItemsNotInCategory.Add(item);
            }
            base.OnNavigatedTo(e);
        }

        private void ItemsList_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private async void AppBarButton_Click_Async(object sender, RoutedEventArgs e)
        {
            var item = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteItemDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                Item removedItem = (Item)item;
                ItemsOfCategory.Remove(removedItem);
                ItemsNotInCategory.Add(removedItem);
                //TODO: Call backend to delete Item
            }
        }

        private void AddItem_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            if(ItemsNotInCategoryComboBox.SelectedIndex < 0)
            {
                ErrorText.Text = "No item selected";
            }
            else
            {
                Item selectedItem = (Item)ItemsNotInCategoryComboBox.SelectedItem;                
                ItemsNotInCategory.Remove(selectedItem);
                ItemsOfCategory.Add(selectedItem);
                //TODO: Call backend to add item with amount to category
            }
        }
    }
}
