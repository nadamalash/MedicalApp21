using MedicalApp21.Services;
using MedicalApp21.ViewModel.GridViews;
using MedicalApp21.ViewModels;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.Popup
{
   public class DeleteConfirm_VM : BaseViewModel

    {
        private char type;
        private int id;
        public DeleteConfirm_VM(char _type, int _id)
        {
            Page_Title = "Delete Confirmation";
            type = _type;
            id = _id;
        }

        //ok Btn
        public ICommand btnOkCommand
        {   
            get => new Command(() => 
            { if (type == 'r')
                    DelImage();
                else
                    DelPatient();
            });

        }

        //cancel Btn
        public ICommand btnCloseCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PopAsync(); });

        }

        private async void DelImage()
        {
            int row = ImgService.DeleteImg(new Model.Img() { ID = id });
            if (row > 0)
                CrossToastPopUp.Current.ShowToastMessage("Deleted Successfully!");

            else
                CrossToastPopUp.Current.ShowToastMessage("Unable To Delete.Please Try Again!");

            if (Results_Grid_VM.PassResults!=null)
              Results_Grid_VM.PassResults.Clear();

            foreach (var img in ImgService.GetPatientImgs(Convert.ToInt32(Settings.ID)))
                Results_Grid_VM.PassResults.Add(img);
            

            await PopupNavigation.Instance.PopAsync();
        }
        private async void DelPatient()
        {
            int row = PatientService.DeletePatient(new Model.Patient() { ID = id });
            if (row > 0)
                CrossToastPopUp.Current.ShowToastMessage("Deleted Successfully!");

            else
                CrossToastPopUp.Current.ShowToastMessage("Unable To Delete.Please Try Again!");

            if(Patients_Grid_VM.PassPatients!=null)
            Patients_Grid_VM.PassPatients.Clear();

            foreach (var patient in PatientService.GetAllPatients())
                Patients_Grid_VM.PassPatients.Add(patient);

            //Delete All Imgs related
            if (ImgService.GetAllImgs() != null)
            {
                foreach (var img in ImgService.GetAllImgs())
                {
                    if(img.PatientID== Convert.ToInt32(Settings.ID))
                        ImgService.DeleteImg(img);
                }
            }

            //Delete All Drugs related
            if (DrugService.GetAllDrugs() != null)
            {
                foreach (var drug in DrugService.GetAllDrugs())
                {
                    if (drug.PatientID == Convert.ToInt32(Settings.ID))
                        DrugService.DeleteDrug(drug);
                }
            }

            await PopupNavigation.Instance.PopAsync();
        }
    }
}
