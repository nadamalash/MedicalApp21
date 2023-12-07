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
   public class Results_Grid_VM : BaseViewModel
   {
        public static ObservableCollection<Img> PassResults;
        private ObservableCollection<Img> allResults;
        public ObservableCollection<Img> AllResults
        {
            get => allResults;

            set
            { SetValue(ref allResults, value); }
        }
        public int MyProperty { get; set; }
        public Results_Grid_VM()
        {
            PassResults = ImgService.GetPatientImgs(Convert.ToInt32(Settings.ID));
            AllResults = PassResults;
        }

        
        //Show Delete Confirmation Btn
        public ICommand showDelConfirmCommand
        {
            get => new Command((p) => { PopupNavigation.Instance.PushAsync(new DeleteConfirm('r', (int)p));});

        }
        public ICommand showDiagnosesCommand
        {
            get => new Command((p) => {    PopupNavigation.Instance.PushAsync(new Details((int)p)); });

        }

    }
}
