using MedicalApp21.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pa_Home : ContentPage
    {
        public Pa_Home()
        {
            InitializeComponent();
            BindingContext = new Pa_Home_VM();

        }

        protected override bool OnBackButtonPressed()
        {
            Pa_Home_VM.disableBack();
            return false;
        }
       

    }
}