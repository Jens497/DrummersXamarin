using AppForTest.Dto;
using AppForTest.Services;
using AppForTest.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    public class LoginViewModel
    {
        private readonly LoginService _loginServices = new LoginService();


        public async Task LoginUser(UserLoginDto user)
        {
            var userStatus = await _loginServices.LoginUserPost(user);
            if (!userStatus.IsFailed)
            {
                await SecureStorage.SetAsync("accessToken", userStatus.AccessToken);
                //Application.Current.Properties.Add("username", register.UserName);
                //Application.Current.Properties.Add("IsLoggedIn", true);
                await Application.Current.SavePropertiesAsync();
                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Login error", userStatus.ErrorMessage, "OK");
        }
    }
}
