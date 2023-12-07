using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
   public class User_Type_VM: BaseViewModel
    {
        private Style patientTypeStyle;
        private Style drTypeStyle;
        private bool nextIsVisible;
        private string SelectedTypeP;
        public Style PatientTypeStyle
        { 
            get => patientTypeStyle;  
            set 
            {
                SetValue(ref patientTypeStyle, value);

                if (patientTypeStyle== App.Current.Resources["TypeImgBtnSelected"])
                {
                    DrTypeStyle = (Style)App.Current.Resources["TypeImgBtn"];
                    NextIsVisible = true;

                }
            }
        }
        public Style DrTypeStyle
        {
            get => drTypeStyle;
         
            set
            { SetValue(ref drTypeStyle, value);

                if (drTypeStyle == App.Current.Resources["TypeImgBtnSelected"])
                {
                    PatientTypeStyle = (Style)App.Current.Resources["TypeImgBtn"];
                    NextIsVisible = true;

                }
            }
        }
        public bool NextIsVisible
        {
            get => nextIsVisible;
            set { SetValue(ref nextIsVisible, value); }
               
        }

        public User_Type_VM()
        {
            Page_Title = "User Type";
            Has_Back = false;
            PatientTypeStyle= (Style)App.Current.Resources["TypeImgBtn"];
            DrTypeStyle = (Style)App.Current.Resources["TypeImgBtn"];
            NextIsVisible = false;
        }

        public ICommand SelectedTypeCommand
        {   
            //Change Style of Btn & show Next
            get => new Command((p) =>
                {  ChangeStyle(p.ToString());
                   SelectedTypeP = p.ToString();  });
        }

        public ICommand NextCommand
        {    //View Home Page
            get => new Command(() => {ViewHome(SelectedTypeP);});
            
        }
        private void ChangeStyle(string type)
        {
            if (type == "patient")
            {
                PatientTypeStyle = (Style)App.Current.Resources["TypeImgBtnSelected"];
                Settings.UserType = "patient";
            }
            else
            {
                DrTypeStyle = (Style)App.Current.Resources["TypeImgBtnSelected"];
                Settings.UserType = "doctor";
            }
           
        }


        private void ViewHome(string type)
        {
            if (type == "patient") {
                App.Current.MainPage.Navigation.PushAsync(new Pa_Home());  }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new Dr_Home());
            }
        }

        //Disable Back
        public static void disableBack() => Device.BeginInvokeOnMainThread(() => System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow());


    }
}
