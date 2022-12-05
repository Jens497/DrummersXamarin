using AppForTest.Dto;
using AppForTest.FileHelpers;
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
        private readonly FileOpener _fileOpener;

        private string newFilePath { get; set; }
        public CreateExcercisePage()
        {
            InitializeComponent();
            _viewModel = new CreateExcerciseViewModel();
            _fileOpener = new FileOpener();
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            if(EName != null && newFilePath != null)
            {
                ExcerciseDto excercise = new ExcerciseDto();
                excercise.Name = EName.Text;
                excercise.Filename = newFilePath;


                await _viewModel.createExcercisePost(excercise);
                await Shell.Current.GoToAsync($"//{nameof(ExcerciseLibrary)}");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Creation error", "Please select a file and give the excercise a name", "OK");
            }

            newFilePath = null;
            
        }

        private async void Pick_file_clicked(object sender, EventArgs e)
        {
            //Use file picker

            var file = await _fileOpener.PickFile();
            newFilePath = file.ToString();

            /*try
            {
                var file = await FilePicker.PickAsync();

                if (file == null)
                    return;

                
                Labelinfo.Text = file.FullPath;
                

            } catch (Exception)
            {

            }*/
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