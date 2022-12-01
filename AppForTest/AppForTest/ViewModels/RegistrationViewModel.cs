using AppForTest.Models;
using AppForTest.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    
    public class RegistrationViewModel
    {
        private readonly LoginService _loginServices = new LoginService();

        public async Task RegisterUser(UserModel user)
        {
            var register = await _loginServices.RegisterUserPost(user);
            if (!register.IsFailed)
            {
                await SecureStorage.SetAsync("accessToken", register.AccessToken);
                Application.Current.Properties.Add("IsLoggedIn", true);
                Application.Current.Properties.Add("username", register.UserName);
                await Application.Current.SavePropertiesAsync();

            }
            else
                await Application.Current.MainPage.DisplayAlert("Registration error", register.ErrorMessage, "OK");
        }
    }
}
