using AppForTest.Models;
using AppForTest.ViewModels;
using System;

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
            //TBD verify that email has a valid form
            //Maybe also check length of username and password?
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