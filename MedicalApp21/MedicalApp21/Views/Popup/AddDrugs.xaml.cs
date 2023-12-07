using MedicalApp21.ViewModel.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21.Views.Popup
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddDrugs 
    {
        public AddDrugs()
        {
            InitializeComponent();
            BindingContext = new AddDrugs_VM();
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}