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
    public partial class AddImage : ContentPage
    {
        public AddImage()
        {
            InitializeComponent();
            BindingContext = new AddImage_VM();

        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}