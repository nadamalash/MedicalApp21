using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
    public class Pa_Home_VM : BaseViewModel
    {

        public Pa_Home_VM()
        {
            Page_Title = "Patient Home";
            Has_Back = false;

        }


        //Show Add Img Page Btn
        public ICommand showAddImgCommand => new Command(() => { App.Current.MainPage.Navigation.PushAsync(new AddImage()); });

        //Disable Back
        public static void disableBack() => Device.BeginInvokeOnMainThread(() => System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow());
    }
}
