using AppForTest.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppForTest
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
            Routing.RegisterRoute(nameof(CreateExcercisePage), typeof(CreateExcercisePage));
        }

    }
}
