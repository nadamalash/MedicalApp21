using MedicalApp21.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.Popup
{
    public class ViewDrugs_VM : BaseViewModel
    {
        public ViewDrugs_VM()
        {
            Page_Title = "View Drugs";
        }

        //ok Btn
        public ICommand btnCloseCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PopAsync(); });

        }
        
    }
}
