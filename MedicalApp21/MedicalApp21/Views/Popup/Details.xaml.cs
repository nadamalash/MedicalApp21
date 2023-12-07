using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalApp21.ViewModel.Popup;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Details 
    {
        public Details(int _id)
        {
            InitializeComponent();
            BindingContext = new Details_VM( _id);
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}