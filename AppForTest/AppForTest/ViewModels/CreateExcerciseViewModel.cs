using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppForTest.Dto;
using AppForTest.Models;
using AppForTest.Services;
using Xamarin.Forms;

namespace AppForTest.ViewModels
{
    public class CreateExcerciseViewModel
    {
        private readonly ExcerciseService _service = new ExcerciseService();

        public async Task createExcercisePost(ExcerciseDto excercise)
        {
            await _service.CreateExcercise(excercise);
        }
    }
}
