using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Essentials;

namespace MedicalApp21.Services
{
    public static class Settings
    {
        
        #region Application.Current.Properties["key"] that uses Xamarin essintial and josn that causes problems so => I used Xamarin Settings plugin instead

        private static Lazy<ISettings> _appSettings;

        public static ISettings AppSettings
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = new Lazy<ISettings>(() => CrossSettings.Current, LazyThreadSafetyMode.PublicationOnly);
                }

                return _appSettings.Value;
            }
            set
            {
                _appSettings = new Lazy<ISettings>(() => value, LazyThreadSafetyMode.PublicationOnly);
            }
        }
        private const string UserTypeKey = "usertype_key"; //Key used to get your property
        private static readonly string UserTypeDefault = string.Empty; //Default value for your property if the key-value pair has not been created yet

        public static string UserType
        {
            get { return AppSettings.GetValueOrDefault(UserTypeKey, UserTypeDefault); }
            set { AppSettings.AddOrUpdateValue(UserTypeKey, value); }
        }

        //Pass ID
        private const string IDKey = "ID_key"; //Key used to get your property
        private static readonly int IDDefault = 0; //Default value for your property if the key-value pair has not been created yet

        public static string ID
        {
            get { return AppSettings.GetValueOrDefault(IDKey, IDDefault.ToString()); }
            set { AppSettings.AddOrUpdateValue(IDKey, value); }
        }

        //Pass Drugs
        private const string DrugsKey = "Drugs_key"; //Key used to get your property
        private static readonly string DrugsDefault = string.Empty; //Default value for your property if the key-value pair has not been created yet

        public static string Drugs
        {
            get { return AppSettings.GetValueOrDefault(DrugsKey, DrugsDefault); }
            set { AppSettings.AddOrUpdateValue(DrugsKey, value); }
        }
        #endregion

        #region Xamarin Essentials To determine First Run
        public static bool FirstRun
        {
            get => Preferences.Get(nameof(FirstRun), true);
            set => Preferences.Set(nameof(FirstRun), value);
        }

        #endregion
    }
}
