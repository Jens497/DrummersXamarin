using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //To logout we give an abselout path to login like the one down below.
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}/{nameof(RegistrationPage)}");
        }
    }
}