using AppForTest.Dto;
using AppForTest.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel loginViewModel;
        //private Metronome playerHelpers;
        public LoginPage()
        {
            InitializeComponent();
            loginViewModel = new LoginViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (EUsername.Text == "" || EPassword.Text == "")
                await Application.Current.MainPage.DisplayAlert("Login error", "Please enter username and password", "OK");
            else
            {
                UserLoginDto userForAuth = new UserLoginDto()
                {
                    Username = EUsername.Text,
                    Password = EPassword.Text,
                };
                await loginViewModel.LoginUser(userForAuth);
                EUsername.Text = "";
                EPassword.Text = "";
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            //Since we are already in the login page, the path through it is not needed!
            await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
        }
    }
}