using AppForTest.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppForTest.ViewModels
{
    public  class HomePageViewModel
    {
        public List<OnBoarding> OnBoardings { get; set; }

        public HomePageViewModel()
        {
            OnBoardings = GetOnBoarding();
        }
        private List<OnBoarding> GetOnBoarding()
        {
            return new List<OnBoarding>
            {
                new OnBoarding{Heading = "Metronome", Caption = "Control the beat you wanna play to. Easy to use metronome for the road!"},
                new OnBoarding{Heading = "Excercise library", Caption = "Gain easy access to you pdfs with the different excercises you do throughout the week!"},
                new OnBoarding{Heading = "Heading three", Caption = "Caption three"}
            };
        }
    }

    public class OnBoarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
}
