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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelListApp.NewFolder1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Register : Page
    {
        public Register()
        {
            this.InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameTextbox.Text == "")
            {
                ErrorText.Text = "Username field can't be empty";
            }
            else if (PasswordBox.Password == "")
            {
                ErrorText.Text = "Password field can't be empty";
            }
            else if (RepeatPasswordBox.Password == "")
            {
                ErrorText.Text = "Confirm Password field can't be empty";
            }else if(PasswordBox.Password != PasswordBox.Password)
            {
                ErrorText.Text = "Password and Confirm Password don't match";
            }
            else
            {
                //TODO: Call to backend to register
                if (true)
                {
                    SuccessText.Text = "You have registered successfully";
                }
                else
                {
                    ErrorText.Text = "An error occurred during the registration";
                }
            }

        }
    }
}
