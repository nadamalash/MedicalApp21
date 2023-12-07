using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using MedicalApp21.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
    public class PatientProfile_VM : BaseViewModel
    {
        private string age;
        private string name;
        private string phone;
        private string address;
        private bool maleIsChecked;
        private bool femaleIsChecked;
        public string Name
        {
            get => name;

            set
            { SetValue(ref name, value); }
        }
        public string Age
        {
            get => age;

            set
            { SetValue(ref age, value); }
        }
        public string Phone
        {
            get => phone;

            set
            { SetValue(ref phone, value); }
        }
        public string Address
        {
            get => address;

            set
            { SetValue(ref address, value); }
        }
        public bool MaleIsChecked
        {
            get => maleIsChecked;

            set
            {
                SetValue(ref maleIsChecked, value);
                if (maleIsChecked == true)
                {
                    FemaleIsChecked = false;

                }
            }
        }
        public bool FemaleIsChecked
        {
            get => femaleIsChecked;

            set
            {
                SetValue(ref femaleIsChecked, value);
                if (femaleIsChecked == true)
                {
                    MaleIsChecked = false;

                }
            }
        }
        public PatientProfile_VM(int _id)
        {
            Page_Title = "Patient Profile";
            Has_Back = true;
            Settings.ID = _id.ToString();
            var patient = PatientService.GetPatient(_id);
            Age = patient.Age.ToString();
            Name = patient.Name;
            Phone = patient.Phone;
            Address = patient.Address;
            if (patient.Gender == "Male")
                MaleIsChecked = true;
            else
                FemaleIsChecked = true;

        }

        //viewDrugs Btn
        public ICommand viewDrugsBtnCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PushAsync(new ViewDrugs()); });



        }
        //showDiagnoses Btn
        public ICommand showDiagnosesBtnCommand
        {
            get => new Command(() => { App.Current.MainPage.Navigation.PushAsync(new Diagnose()); });

        }
        
    }
}
