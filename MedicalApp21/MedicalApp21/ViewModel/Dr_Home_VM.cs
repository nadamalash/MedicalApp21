using MedicalApp21.Popup;
using MedicalApp21.Services;
using MedicalApp21.ViewModel.GridViews;
using MedicalApp21.Views;
using MedicalApp21.Views.Popup;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModels
{
    public class Dr_Home_VM : BaseViewModel
    {
        public Dr_Home_VM()
        {
            Page_Title = "Doctor Home";
            Has_Back = false;
        }

        //Search bar Command
        public ICommand searchBarCommand => new Command((p) => { whenTextChanged(p.ToString()); });

        //Show Add Patient Page Btn
        public ICommand addPatientBtnCommand => new Command(() => { App.Current.MainPage.Navigation.PushAsync(new AddPatient()); });

        private void whenTextChanged(string _searchtext)
        {
            if (_searchtext == null)
            {
                if (Patients_Grid_VM.PassPatients != null)
                    Patients_Grid_VM.PassPatients.Clear();

                foreach (var pat in PatientService.GetAllPatients())
                    Patients_Grid_VM.PassPatients.Add(pat);
            }
             
            else
            {
                if (Patients_Grid_VM.PassPatients != null)
                    Patients_Grid_VM.PassPatients.Clear();

                foreach (var pat in PatientService.GetPatientsWithName(_searchtext))
                    Patients_Grid_VM.PassPatients.Add(pat);
            }
        }
        //Disable Back
        public static void disableBack() => Device.BeginInvokeOnMainThread(() => System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow());
    }
}
