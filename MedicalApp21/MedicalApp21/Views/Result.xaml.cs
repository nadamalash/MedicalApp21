using MedicalApp21.ViewModel;
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
    public partial class Result : ContentPage
    {
        public Result(int _patientID, string _description, ResultE _result, byte[] _name)
        {
            InitializeComponent();
            BindingContext = new Result_VM(_patientID,_description, _result, _name);
        }
        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}