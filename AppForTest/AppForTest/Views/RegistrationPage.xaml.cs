using AppForTest.Models;
using AppForTest.ViewModels;
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
    public partial class RegistrationPage : ContentPage
    {
        private readonly RegistrationViewModel registrationViewModel;
        public RegistrationPage()
        {
            InitializeComponent();
            registrationViewModel = new RegistrationViewModel();
        }

        private async void Register_Clicked(object sender, EventArgs e)
        {
            if(EUsername.Text == "")
                await Application.Current.MainPage.DisplayAlert("Registration error", "Username and password cannot be empty", "OK");
            else if(EPassword.Text != ERepeatPassword.Text)
            {
                await Application.Current.MainPage.DisplayAlert("Registration error", "Password needs to be the same!", "OK");
            }
            else
            {
                UserModel user = new UserModel()
                {
                    Username = EUsername.Text,
                    Password = EPassword.Text,
                    Email = EEmail.Text,
                    Firstname = EFirstname.Text,
                    Lastname = ELastname.Text,
                };
                await registrationViewModel.RegisterUser(user);
            }
            resetTextFields();

            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }

        private void resetTextFields()
        {
            EUsername.Text = "";
            EPassword.Text = "";
            ERepeatPassword.Text = "";
            EEmail.Text = "";
            EFirstname.Text = "";
            ELastname.Text = "";
        }
    }
}