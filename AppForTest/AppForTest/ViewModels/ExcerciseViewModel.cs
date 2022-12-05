using AppForTest.Models;
using AppForTest.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    public class ExcerciseViewModel
    {
        private readonly ExcerciseService _service = new ExcerciseService();
        //public ObservableCollection<ExcerciseModel> Excercises { get; set; }

        public async Task<List<ExcerciseModel>> populateCollection()
        {
            List<ExcerciseModel> exercises = await _service.GetExcercises();

            return exercises;
        }

        public async Task DeleteExcercise(int excerciseId)
        {
            await _service.DeleteExcercise(excerciseId);
        }
    }
}
