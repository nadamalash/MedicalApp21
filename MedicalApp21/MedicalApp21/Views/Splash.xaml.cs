using MedicalApp21.Services;
using MedicalApp21.ViewModel;
using MedicalApp21.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();
            BindingContext = new Splash_VM();
        }
        protected override void OnAppearing() => Splash_VM.whichIsAppeared();
    }
}