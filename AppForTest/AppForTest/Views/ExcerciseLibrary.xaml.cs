using AppForTest.FileHelpers;
using AppForTest.Models;
using AppForTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExcerciseLibrary : ContentPage
    {
        private readonly ExcerciseViewModel _viewModel;
        private readonly FileOpener _opener;
        public ExcerciseLibrary()
        {
            InitializeComponent();
            _viewModel = new ExcerciseViewModel();
            _opener = new FileOpener();

            //Not accurate MVVM but for some reason I just cant make it work by it takeing and items source from the ViewModel, even when I do it through a command
            ExcerciseList.RefreshCommand = new Command(() =>
            {
                OnAppearing();
            });
        }

        protected override async void OnAppearing()
        {
            List<ExcerciseModel> excercises = await _viewModel.populateCollection();

            if (excercises != null)
            {
                var excerciseConverted = new ObservableCollection<ExcerciseModel>(excercises);
                
                ExcerciseList.ItemsSource = excerciseConverted;
          }
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var excercise = e.Item as ExcerciseModel;
            //await _viewModel.DeleteExcercise(excercise.Id);
            var fileOpeningStatus = await _opener.OpenFile(excercise.Filename);
            if (!fileOpeningStatus)
                await Application.Current.MainPage.DisplayAlert("File not found", "The file could not be found!", "OK");
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var excercise = ((MenuItem)sender).BindingContext as ExcerciseModel;
            if (excercise == null)
                return;
            await _viewModel.DeleteExcercise(excercise.Id);

            await Application.Current.MainPage.DisplayAlert("Excercise deleted", excercise.Name, "OK");
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"{nameof(CreateExcercisePage)}");
        }
    }
}