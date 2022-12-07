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
    public partial class MetronomePage : ContentPage
    {
        private readonly MetronomePageViewModel _viewModel;
        public MetronomePage()
        {
            InitializeComponent();
            _viewModel = new MetronomePageViewModel();
        }

        private async void Time_signature_Clicked(object sender, EventArgs e)
        {
            _viewModel.SetTimesignature(await DisplayActionSheet("Choose time singautre", "Cancel", null, "4/4", "8/4"));
            
        }

        private async void Subdivision_Clicked(object sender, EventArgs e)
        {
            _viewModel.SetSubdivision(await DisplayActionSheet("Choose subdivision", "Cancel", null, "4th", "8th"));
        }

        private async void Play_Clicked(object sender, EventArgs e)
        {
            int bpmToSend;
            try
            {
                bpmToSend = int.Parse(EBpm.Text);
            }catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Bpm invalid", "Please select a valid bpm between the ranges 60-250", "OK");
                return;
            }
            if (bpmToSend < 60 || bpmToSend > 250)
            {
                await Application.Current.MainPage.DisplayAlert("Bpm invalid", "Please select a valid bpm between the ranges 60-250", "OK");
                return;
            }
            
            //if (EBpm.Text == "")
            //    await Application.Current.MainPage.DisplayAlert("Bpm not selected", "Please select a bmp for the metronome", "OK");

            _viewModel.SetupAndStartMetronome(bpmToSend);
            
        }

        private void Stop_Clicked(object sender, EventArgs e)
        {
            _viewModel.StopMetronome();
        }
    }
}