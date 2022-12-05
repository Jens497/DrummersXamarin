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
                new OnBoarding{Heading = "Heading one", Caption = "Caption one"},
                new OnBoarding{Heading = "Heading two", Caption = "Caption two"},
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
