using MedicalApp21.Model;
using MedicalApp21.Services;
using MedicalApp21.ViewModel.GridViews;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
  public class Result_VM : BaseViewModel
    {
        private int patientID;
        private byte[] name;
        private Style resultLblStyle;
        private string result;
        private string description;

        public Style ResultLblStyle
        {
            get => resultLblStyle;
            set
            { SetValue(ref resultLblStyle, value); }
        }
        public string Result
        {
            get => result;
            set
            {
                SetValue(ref result, value);

                if (result == "Positive")
                    ResultLblStyle = (Style)App.Current.Resources["PositiveLbl"];
                else if(result == "Negative")
                    ResultLblStyle = (Style)App.Current.Resources["NegativeLbl"];
                else
                    ResultLblStyle = (Style)App.Current.Resources["UnKnownLbl"];


            }
        }
        public string Description
        {
            get => description;
            set
            { SetValue(ref description, value); }
        }

        public Result_VM(int _patientID, string _description, ResultE _result, byte[] _name)
        {
            Page_Title = "Result";
            Has_Back = true;
            Result = _result.ToString();
            Description = _description;
            name = _name;
            patientID = _patientID;
        }
        //Save Result Btn
        public ICommand saveResultBtnCommand
        {
            get => new Command(() => { SaveImg(); });

        }

        private async void BackToHome()
        {
            for (var counter = 1; counter < 2; counter++)
            {
                App.Current.MainPage.Navigation.RemovePage(App.Current.MainPage.Navigation.NavigationStack[App.Current.MainPage.Navigation.NavigationStack.Count - 2]);
            }
            await App.Current.MainPage.Navigation.PopAsync();
        }
        private void SaveImg()
        {
           int row = ImgService.AddImg(new Img() {Name=this.name, Result=this.Result,Description=this.Description,Date=DateTime.Now,PatientID=this.patientID });
            if (row>0)
            CrossToastPopUp.Current.ShowToastMessage("Saved Successfully!");
            
            else
            CrossToastPopUp.Current.ShowToastMessage("Unable To Save.Please Try Again!");

            //init Pass Result if it's first time to show
            if(Results_Grid_VM.PassResults==null)
            Results_Grid_VM.PassResults = ImgService.GetPatientImgs(Convert.ToInt32(Settings.ID));

            
                Results_Grid_VM.PassResults.Clear();

            foreach (var img in ImgService.GetPatientImgs(Convert.ToInt32(Settings.ID)))
                Results_Grid_VM.PassResults.Add(img);

            BackToHome();
        }
     }
}
