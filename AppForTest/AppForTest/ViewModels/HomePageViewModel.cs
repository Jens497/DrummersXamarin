using System.Collections.Generic;

namespace AppForTest.ViewModels
{
    public  class HomePageViewModel
    {
        public List<OnBoarding> OnBoardings { get; set; }

        public HomePageViewModel()
        {
            OnBoardings = GetOnBoarding();
        }
        //Dummy onboarding text, this would be eventually made to a list which it would take from.
        private List<OnBoarding> GetOnBoarding()
        {
            return new List<OnBoarding>
            {
                new OnBoarding{Heading = "Metronome", Caption = "Control the beat you wanna play to. Easy to use metronome for the road!"},
                new OnBoarding{Heading = "Excercise library", Caption = "Gain easy access to you pdfs with the different excercises you do throughout the week!"},
            };
        }
    }

    public class OnBoarding
    {
        public string Heading { get; set; }
        public string Caption { get; set; }
    }
}
