using MedicalApp21.Model;
using MedicalApp21.Services;
using MedicalApp21.ViewModel.GridViews;
using MedicalApp21.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.Popup
{
    public class AddDrugs_VM : BaseViewModel
    {
        private string drugname;
        public string Drugname
        {
            get => drugname;

            set
            { SetValue(ref drugname, value); }
        }
        public AddDrugs_VM()
        {
            Page_Title = "Add Drugs";

        }

        //Add Drug Name Btn
        public ICommand btndrugNameCommand
        {
            get => new Command(() => { AddDrugName(); });

        }
        //ok Btn
        public ICommand btnOkCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PopAsync();
                Settings.Drugs = string.Empty;
            });

        }

        //cancel Btn
        public ICommand btnCloseCommand
        {
            get => new Command(() => { ClearAllDrugs(); });

        }
        private void AddDrugName()
        {
            Settings.Drugs += $"{Drugname }/";

            //Split Drugs String
            string[] drugNames = Settings.Drugs.Split('/');

            Drugs_Grid_VM.PassDrugs.Clear();

            foreach (var name in drugNames)
              Drugs_Grid_VM.PassDrugs.Add(new Drug() { Name = $"{name}" });
            

            Drugname = string.Empty;
        }

        private void ClearAllDrugs()
        {
            Settings.Drugs = string.Empty;
            PopupNavigation.Instance.PopAsync();
        }
    }
}
