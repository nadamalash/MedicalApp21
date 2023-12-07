using MedicalApp21.ViewModel;
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
    public partial class Diagnose : ContentPage
    {
        public Diagnose()
        {
            InitializeComponent();
            BindingContext = new Diagnose_VM();

        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}