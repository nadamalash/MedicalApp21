using MedicalApp21.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.Popup
{
   public class ImgAlert_VM : BaseViewModel
    {
        private string alertMsg;
        public string AlertMsg
        {
            get => alertMsg;

            set
            { SetValue(ref alertMsg, value); }

        }

        public ImgAlert_VM(char _msgType)
        {
            Page_Title = "Alert !";
            if ( _msgType == 'c')
                AlertMsg = "If the captured image is unclear or not of high quality, processing will not be completed";
            else
                AlertMsg = "If the uploaded image is unclear or not of high quality, processing will not be completed";

        }

        //ok Btn
        public ICommand btnOkCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PopAsync(); });

        }

      
    }
}
