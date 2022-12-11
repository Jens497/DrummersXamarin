using AppForTest.Dto;
using AppForTest.Services;
using AppForTest.Views;
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
                await SecureStorage.SetAsync("accessToken", userStatus.UserAccessToken);

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error from Login", userStatus.ErrorMessage, "OK");
        }
    }
}
