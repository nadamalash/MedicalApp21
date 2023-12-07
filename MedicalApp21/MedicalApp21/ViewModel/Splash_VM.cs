using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
    public class Splash_VM : BaseViewModel
    {
        private ImageSource imgSource;
        public ImageSource ImgSource
        {
            get => imgSource;

            set
            { SetValue(ref imgSource, value); }
        }
        public Splash_VM()
        {
            ImgSource = ImageSource.FromResource("MedicalApp21.Images.Dr.jpg");
        }
        public async static void whichIsAppeared()
        {
            await Task.Delay(2000);

            if (Settings.FirstRun)
            {
                // Perform an action (Show userType)
                Settings.UserType = "nothing";
                await App.Current.MainPage.Navigation.PushAsync(new User_Type());
                Settings.FirstRun = false;
            }
            else
            {
                if (Settings.UserType == "patient")
                {
                    //Load if Patient
                    await App.Current.MainPage.Navigation.PushAsync(new Pa_Home());
                }
                else if (Settings.UserType == "doctor")
                {
                    //Load if Doctor
                    await App.Current.MainPage.Navigation.PushAsync(new Dr_Home());
                }
                else
                {
                    //Load if isn't the first run & user type not defined
                    await App.Current.MainPage.Navigation.PushAsync(new User_Type());
                }
            }

        }
    }
}

