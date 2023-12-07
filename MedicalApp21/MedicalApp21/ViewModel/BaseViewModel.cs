using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MedicalApp21.ViewModels
{
   public class BaseViewModel : INotifyPropertyChanged
    {
        public string Page_Title { get; set; }
        public bool Has_Back { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public void SetValue<T>(ref T backingField, T value, [CallerMemberName] string propertyname = null) 
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;

            backingField = value;
            OnPropertyChanged(propertyname);
        }

        //Back Btn
        public ICommand BackBtnCommand
        {
            get => new Command(() => { App.Current.MainPage.Navigation.PopAsync(); });

        }
        

    }
}
