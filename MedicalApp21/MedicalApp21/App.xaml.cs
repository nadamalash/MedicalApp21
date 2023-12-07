using MedicalApp21.Services;
using MedicalApp21.ViewModel;
using MedicalApp21.Views;
using Newtonsoft.Json;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public App(string databaseLocation)
        {  
            InitializeComponent();
            MainPage = new NavigationPage(new Splash());

            //DB Location & Table Creation
            DatabaseLocation = databaseLocation;
            DataAccess.CreateLocaldbTables();
            }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
