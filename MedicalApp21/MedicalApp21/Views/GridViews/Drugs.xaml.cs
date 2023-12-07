using MedicalApp21.ViewModel.GridViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedicalApp21.Views.GridViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Drugs : ContentView
    {
        public Drugs()
        {
            InitializeComponent();
            BindingContext = new Drugs_Grid_VM();
        }
    }
}