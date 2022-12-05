﻿using AppForTest.Models;
using AppForTest.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppForTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExcerciseLibrary : ContentPage
    {
        private readonly ExcerciseViewModel _viewModel;
        public ExcerciseLibrary()
        {
            InitializeComponent();
            _viewModel = new ExcerciseViewModel();

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

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var excercise = e.Item as ExcerciseModel;
            Console.WriteLine(excercise.Id);
            //await _viewModel.DeleteExcercise(excercise.Id);
        }

        private async void MenuItem_Clicked(object sender, EventArgs e)
        {
            var excercise = ((MenuItem)sender).BindingContext as ExcerciseModel;
            Console.WriteLine(excercise.Id);
            if (excercise == null)
                return;
            await _viewModel.DeleteExcercise(excercise.Id);

            await Application.Current.MainPage.DisplayAlert("Excercise deleted", excercise.Name, "OK");
        }

        private async void Create_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(CreateExcercisePage)}");
        }
    }
}