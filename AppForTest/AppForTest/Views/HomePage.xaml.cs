using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppForTest.Services;
using System.Runtime.CompilerServices;
using AppForTest.Models;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private UserService _userService = new UserService();
        public HomePage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            List<UserModel> users = new List<UserModel>();
            users = await GetUserModelsAsync();
        }

        public async Task<List<UserModel>> GetUserModelsAsync()
        {
            List<UserModel> users = await _userService.GetUserModelsAsync();
            return users;
        }
    }
}