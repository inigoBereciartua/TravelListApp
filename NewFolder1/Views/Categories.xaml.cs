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
    public sealed partial class Categories : Page
    {
        public ObservableCollection<Category> categoriesList { get; set; } = new ObservableCollection<Category>();
        public Categories()
        {
            this.InitializeComponent();
            //TODO: Call to backend to get categories
            foreach (var category in CategoriesManager.GetCategories())
            {
                categoriesList.Add(category);
            }
            CategoriesGridView.ItemsSource = categoriesList;
        }

        private void CreateCategory_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            if (NewCategoryName.Text == "")
            {
                ErrorText.Text = "Category's name can't be empty";
            }
            else if (NameOfCategoryIsInUse(NewCategoryName.Text))
            {
                ErrorText.Text = "That category name is already in use";
            }
            else
            {
                categoriesList.Add(new Category { Name = NewCategoryName.Text });
                //TODO: Call backend to create Category
            }
        }

        private bool NameOfCategoryIsInUse(string text)
        {
            foreach(var category in categoriesList)
            {
                if(category.Name == text)
                {
                    return true;
                }
            }
            return false;
        }

        private async void AppBarButton_Click_Async(object sender, RoutedEventArgs e)
        {
            var category = (sender as AppBarButton).DataContext;
            ContentDialogResult result = await deleteCategoryDialog.ShowAsync();
            if (result == ContentDialogResult.Primary)
            {
                categoriesList.Remove((Category)category);
                //TODO: Call backend to delete Item
            }
        }

        private void CategoriesGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var category = (Category)e.ClickedItem;
            this.Frame.Navigate(typeof(CategoryDetails),category);
        }
    }
}
