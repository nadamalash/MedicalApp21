using MedicalApp21.Model;
using MedicalApp21.Popup;
using MedicalApp21.Services;
using MedicalApp21.ViewModels;
using MedicalApp21.Views;
using Newtonsoft.Json.Linq;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Toast;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModel
{
    public enum ResultE
    {
        Positive,
        Negative,
        Unknown

    }
    public class AddImage_VM : BaseViewModel
    {
        private int patientID;
        private ResultE result;
        private string description;
        private byte[] name;
        CancellationToken token;
        private MediaFile file;
        private ImageSource imgSource;
        public ImageSource ImgSource
        {
            get => imgSource;

            set
            { SetValue(ref imgSource, value); }
        }
  
        public AddImage_VM()
        {
            Page_Title = "CT Scan";
            Has_Back = true;
            patientID = Convert.ToInt32(Settings.ID);
            description = "Not Valid!";
            result = ResultE.Unknown;
        }


        // Btn Camera
        public ICommand btnCameraCommand
        {
            get => new Command(() => { OpenCamera(); });

        }

        // Btn Gallery
        public ICommand btnGalleryCommand
        {
            get => new Command(() => { OpenGallery(); });

        }

        // Btn Process
        public  ICommand processCommand
        {
            get => new Command(() => {Processing(); });

        }
        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }
        private async void OpenCamera()
        {
            var crossMedia = CrossMedia.Current;
            if (crossMedia.IsCameraAvailable && crossMedia.IsTakePhotoSupported)
            {
                //Take photo
                 file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium,
                    Directory = "XRay",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;
                //show alert
                await PopupNavigation.Instance.PushAsync(new ImgAlert('c'));
                ImgSource = ImageSource.FromFile(file.Path);

                //insertImgData that will store in DB
                name = GetImageBytes(file.GetStream());
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No camera avaialble");
                return;
            }
        }
        private async void OpenGallery()
        {
            var crossMedia = CrossMedia.Current;
            if (crossMedia.IsPickPhotoSupported)
            {
                //Upload photo
                 file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions(), token);

                if (file == null)
                    return;

                //show alert
                await PopupNavigation.Instance.PushAsync(new ImgAlert('g'));
                ImgSource = ImageSource.FromFile(file.Path);

                //insertImgData that will store in DB
                name = GetImageBytes(file.GetStream());
            }
            else
            {
                CrossToastPopUp.Current.ShowToastMessage("No pick photo avaialble");
                return;
            }
        }
   
        private async void Processing()
        {
            if (file == null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Result(patientID, description, result, name));
                return;
            }
               
            var image = System.Guid.NewGuid();

            await PopupNavigation.Instance.PushAsync(new Processing());

           // CrossToastPopUp.Current.ShowToastMessage("Processing ...");

            await UploadFileMPUHighLevelAPI.UploadFileAsync(file.Path, "nada-bucket-frankfurt", image.ToString());
           
            var output= await JsonH.getData("https://kju4r3zisg.execute-api.eu-central-1.amazonaws.com/dev/api/getresult", image.ToString());
            
            if ( output.ToString() == "-1"|| output.ToString() == "0"|| output.ToString() == null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new Result(patientID, description, result, name));
                return;

            }
            else
            {
                var arr = output.ToString().Split(',');
                if (arr[0] == "1")
                {
                    description = $"NEGATIVE case with accuracy: {arr[1]} \n\nThis is considered NORMAL.";
                    result = ResultE.Negative;


                }
                else if (arr[0] == "2")
                {
                   description = $"POSITIVE case with accuracy: {arr[1]} \n\nThis is considered ABNORMAL.";
                   result = ResultE.Positive;

                }

            }

            await PopupNavigation.Instance.PopAsync();

            await App.Current.MainPage.Navigation.PushAsync(new Result(patientID, description, result, name));


        }


    }   
}
