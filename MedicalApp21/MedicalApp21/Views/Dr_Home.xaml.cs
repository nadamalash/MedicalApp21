using MedicalApp21.ViewModels;
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
    public partial class Dr_Home : ContentPage
    {
        public Dr_Home()
        {
            InitializeComponent();
            BindingContext = new Dr_Home_VM();
        }
        protected override bool OnBackButtonPressed()
        {
            Dr_Home_VM.disableBack();
            return false;
        }
    
       
      
    }
}