using MedicalApp21.Model;
using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MedicalApp21.ViewModel.GridViews
{
   public class Drugs_Grid_VM : BaseViewModel
    {
        public static ObservableCollection<Drug> PassDrugs;
        private ObservableCollection<Drug> allDrugs;
        public ObservableCollection<Drug> AllDrugs
        {
            get => allDrugs;

            set
            { SetValue(ref allDrugs, value); }
        }

        public Drugs_Grid_VM()
        {
            //init data for teeeesssttt
            //DrugService.AddAllDrugs(new ObservableCollection<Drug>(new List<Drug>() { new Drug() { Name = "Paaanaandooool1111", PatientID = 1 }, new Drug() { Name = "Paaanaandooookhjgkl", PatientID = 1 }, new Drug() { Name = "Paaanaandooool22222", PatientID = 2 }, }));
           PassDrugs = DrugService.GetPatientDrugs(Convert.ToInt32(Settings.ID));
            AllDrugs = PassDrugs;
        }

       
    }
}
