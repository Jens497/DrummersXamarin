using AppForTest.Models;
using AppForTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    public class ExcerciseViewModel
    {
        private readonly ExcerciseService _service = new ExcerciseService();
        public ObservableCollection<ExcerciseModel> Excercises { get; set; }


        public async Task<List<ExcerciseModel>> populateCollection()
        {
            List<ExcerciseModel> excercises = await _service.GetExcercises();
            var excerciseConverted = new ObservableCollection<ExcerciseModel>(excercises);
            Excercises = excerciseConverted;
            Console.WriteLine("Getting the excercises");
            Console.WriteLine(Excercises.Count);

            return excercises;
        }

        public async Task DeleteExcercise(int excerciseId)
        {
            await _service.DeleteExcercise(excerciseId);
        }

        /*private bool _isRefreshing = false;
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
            }
        }

        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await RefreshData();

                    IsRefreshing = false;
                });
            }
        }*/

        public async Task RefreshData()
        {
            List<ExcerciseModel> excercises = await populateCollection();

            if (excercises != null)
            {
                var excerciseConverted = new ObservableCollection<ExcerciseModel>(excercises);
                Excercises = excerciseConverted;
            }
        }
    }
}
