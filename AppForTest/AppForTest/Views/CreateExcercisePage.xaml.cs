using AppForTest.Dto;
using AppForTest.ViewModels;
using Newtonsoft.Json.Converters;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;
using File = System.IO.File;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateExcercisePage : ContentPage
    {
        private readonly CreateExcerciseViewModel _viewModel;
        public CreateExcercisePage()
        {
            InitializeComponent();
            _viewModel = new CreateExcerciseViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if(EName != null && EFilename != null)
            {
                ExcerciseDto excercise = new ExcerciseDto();
                excercise.Name = EName.Text;
                excercise.Filename = EFilename.Text;


                await _viewModel.createExcercisePost(excercise);
                await Shell.Current.GoToAsync($"//{nameof(ExcerciseLibrary)}");
            }
            
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            try
            {
                var file = await FilePicker.PickAsync();

                if (file == null)
                    return;

                
                Labelinfo.Text = file.FullPath;
                

            } catch (Exception)
            {

            }
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(Labelinfo.Text)
            });
            
        }
    }
}