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
    public partial class User_Type : ContentPage
    {
        public User_Type()
        {
            InitializeComponent();
            BindingContext = new User_Type_VM();
            
        }

        protected override bool OnBackButtonPressed()
        {
            User_Type_VM.disableBack();
            return false;
        }

    }
}