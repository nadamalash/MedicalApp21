using MedicalApp21.Services;
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
    public partial class Results_Grid : ContentView
    {
        public Results_Grid()
        {
            InitializeComponent();
            BindingContext = new Results_Grid_VM();

        }
    }
}