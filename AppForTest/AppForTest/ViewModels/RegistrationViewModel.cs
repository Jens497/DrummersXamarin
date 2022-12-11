using AppForTest.Models;
using AppForTest.Services;
using AppForTest.Views;
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
            var userStatus = await _loginServices.RegisterUserPost(user);
            if (!userStatus.IsFailed)
            {
                await SecureStorage.SetAsync("accessToken", userStatus.UserAccessToken);

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
            else
                await Application.Current.MainPage.DisplayAlert("Error from registration", userStatus.ErrorMessage, "OK");
        }
    }
}
