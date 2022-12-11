using AppForTest.Models;
using AppForTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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

            return excercises;
        }

        public async Task DeleteExcercise(int excerciseId)
        {
            await _service.DeleteExcercise(excerciseId);
        }

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
