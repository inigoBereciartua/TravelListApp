using System;
using System.Reflection;
using TravelListApp.NewFolder1.Views;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.NewFolder1
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class NavView : Page
    {
        public NavView()
        {
            this.InitializeComponent();            
            ContentFrame.Navigate(typeof(Travels));
            
        }

        private void NavView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {

            }
            else
            {
                var item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag)
                {
                    case "Travels":
                        ContentFrame.Navigate(typeof(Travels));
                        break;
                    case "Items":
                        ContentFrame.Navigate(typeof(Items));
                        break;
                    case "Categories":
                        ContentFrame.Navigate(typeof(Categories));
                        break;
                    case "Tasks":
                        ContentFrame.Navigate(typeof(Tasks));
                        break;
                    case "Calendar":
                        ContentFrame.Navigate(typeof(Calendar));
                        break;

                }
            }
        }    
    }
}
