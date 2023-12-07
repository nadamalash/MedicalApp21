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
    public partial class PatientProfile : ContentPage
    {
        public PatientProfile(int _id)
        {
            InitializeComponent();
            BindingContext = new PatientProfile_VM(_id);
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}