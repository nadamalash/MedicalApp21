using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using Rg.Plugins.Popup.Services;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel.Popup
{
    public class Details_VM : BaseViewModel
    {
        private ImageSource imgSource;
        private string description;

        public ImageSource ImgSource
        {
            get => imgSource;

            set
            { SetValue(ref imgSource, value); }
        }
        public string Description
        {
            get => description;
            set
            { SetValue(ref description, value); }
        }
        public Details_VM(int _id)
        {
            Page_Title = "Radiology Report";
            ImgSource= ImageSource.FromStream(() => {return BytesToStream(ImgService.GetImg(_id).Name);});
            Description ="\n"+ ImgService.GetImg(_id).Description;

        }

        //ok Btn
        public ICommand btnCloseCommand
        {
            get => new Command(() => { PopupNavigation.Instance.PopAsync(); });

        }
        private Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
       
    }
}
