using MedicalApp21.Model;
using MedicalApp21.Services;
using MedicalApp21.ViewModel.GridViews;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using MedicalApp21.Views.Popup;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
    public enum GenderE
    {
        Male,
        Female

    }
    public class AddPatient_VM : BaseViewModel
    {
        private string age;
        private string name;
        private string phone;
        private string address;
        private bool maleIsChecked;
        private bool femaleIsChecked;
        private GenderE gender;
        private bool validate;

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
            { SetValue(ref maleIsChecked, value);
                if (maleIsChecked == true)
                {
                    FemaleIsChecked = false;
                    gender = GenderE.Male;

                }
            }
        }
        public bool FemaleIsChecked
        {
            get => femaleIsChecked;

            set
            { SetValue(ref femaleIsChecked, value);
                if (femaleIsChecked == true)
                {
                    MaleIsChecked = false;
                    gender = GenderE.Female;

                }
            }
        }
        public AddPatient_VM()
        {
            Page_Title = "Add Patient";
            Has_Back = true;
            Settings.ID = "0";
            validate = true;
        }

        //Show Add DrugsPop Btn
        public ICommand addDrugsBtnCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PushAsync(new AddDrugs()); });



        }
        //savePatient Btn
        public ICommand savePatientCommand
        {
            get => new Command(() => { AddPatient();  });

        }
        private void Validation()
        {
            validate = true;
            //Name Validation
            bool isNumeric = false;
            if (!String.IsNullOrEmpty(this.Name))
            foreach (char c in this.Name)
            {
                if (char.IsDigit(c))
                {
                        isNumeric = true;
                    break;
                }
            }

            if (String.IsNullOrEmpty(this.Name) || isNumeric || this.Name.Length > 30)
            {
                this.Name = null;
                isNumeric = false;
                CrossToastPopUp.Current.ShowToastError("You have entered an invalid Value.Please Try Again!");
                validate = false;
            }
            //Phone Validation
            if (!String.IsNullOrEmpty(this.Phone))
            {
                isNumeric = int.TryParse(this.Phone, out _);
            }
            if (String.IsNullOrEmpty(this.Phone) || isNumeric==false ||this.Phone.Length!=11)
            {
                this.Phone = null;
                isNumeric = false;
                CrossToastPopUp.Current.ShowToastError("You have entered an invalid Value.Please Try Again!");
                validate = false;
            }
            //Address Validation
            if (String.IsNullOrEmpty(this.Address))
            {
                CrossToastPopUp.Current.ShowToastError("You have entered an invalid Value.Please Try Again!");
                validate = false;

            }

            //Age Validation
            if (!String.IsNullOrEmpty(this.Age))
            {
                isNumeric = int.TryParse(this.Age, out _);
            }
            if (String.IsNullOrEmpty(this.Age) || isNumeric == false || this.Age.Length != 2)
            {
                this.Age = null;
                isNumeric = false;
                CrossToastPopUp.Current.ShowToastError("You have entered an invalid Value.Please Try Again!");
                validate = false;
            }

            //Gender Validation
            if (MaleIsChecked == false && FemaleIsChecked == false)
            {
                validate = false;
                CrossToastPopUp.Current.ShowToastError("You have entered an invalid Value.Please Try Again!");
            }

        }
        private void AddPatient()
        {
            Validation();
      
            if (validate == true)
            {
                Patient patient = new Patient() { Name = this.Name, Phone = this.Phone, Address = this.Address, Age = Convert.ToInt32(this.Age), Gender = this.gender.ToString() };
                int row = PatientService.AddPatient(patient);
                if (row > 0)
                {
                    if (Drugs_Grid_VM.PassDrugs != null)
                    {
                        foreach (var drug in Drugs_Grid_VM.PassDrugs)
                        {
                            DrugService.AddDrug(new Drug() { Name = drug.Name, PatientID = patient.ID, ToBeKey = $"{patient.ID}{drug.Name}" });
                        }
                    }

                    CrossToastPopUp.Current.ShowToastMessage("Saved Successfully!");
                }

                else
                    CrossToastPopUp.Current.ShowToastMessage("Unable To Save.Please Try Again!");

                Settings.Drugs = string.Empty;

                if (Drugs_Grid_VM.PassDrugs != null)
                    Drugs_Grid_VM.PassDrugs.Clear();

                foreach (var drug in DrugService.GetPatientDrugs(Convert.ToInt32(Settings.ID)))
                    Drugs_Grid_VM.PassDrugs.Add(drug);

                if (Patients_Grid_VM.PassPatients != null)
                    Patients_Grid_VM.PassPatients.Clear();

                foreach (var pat in PatientService.GetAllPatients())
                    Patients_Grid_VM.PassPatients.Add(pat);

                App.Current.MainPage.Navigation.PopAsync();
            }

        }
        
    }
}
