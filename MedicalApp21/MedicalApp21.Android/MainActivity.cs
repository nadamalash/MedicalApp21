using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Plugin.Media;
using System.IO;

namespace MedicalApp21.Droid
{
    [Activity(Label = "CT Scan Interpretation", Icon = "@mipmap/Logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Rg.Plugins.Popup.Popup.Init(this);
            await CrossMedia.Current.Initialize();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            string DBFileName = "GProj.db";
            string baseFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string fullpath = Path.Combine(baseFolder, DBFileName);
            LoadApplication(new App(fullpath));

            //BarColor
            Window.SetStatusBarColor(Android.Graphics.Color.Argb(255,21,28,56));
         

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}