using MedicalApp21.Model;
using MedicalApp21.Popup;
using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.GridViews
{
   public class Patients_Grid_VM : BaseViewModel
    {
        public static ObservableCollection<Patient> PassPatients;
        private ObservableCollection<Patient> allPatients;

        public ObservableCollection<Patient> AllPatients
        {
            get => allPatients;

            set
            {SetValue(ref allPatients, value);}
        }

        public Patients_Grid_VM()
        {
            PassPatients = PatientService.GetAllPatients();
            AllPatients = PassPatients;
        }

        //Show Patient Profile Btn
        public ICommand showProfileCommand
        {
            get => new Command((p) => {
                Settings.ID = p.ToString();
                App.Current.MainPage.Navigation.PushAsync(new PatientProfile((int)p));
            });

        }

        //Show Add Img Page Btn
        public ICommand showAddImgCommand
        {
            get => new Command((p) => {
                Settings.ID = p.ToString();
                App.Current.MainPage.Navigation.PushAsync(new AddImage());
            });

        }

        //Show Delete Confirmation Btn
        public ICommand showDelConfirmCommand
        {
            get => new Command((p) => {
                Settings.ID = p.ToString();
                PopupNavigation.Instance.PushAsync(new DeleteConfirm('p', (int)p));
            });

        }
        
    }
}
