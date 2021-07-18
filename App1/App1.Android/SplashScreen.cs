using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App1.Droid
{
    [Activity(MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true, ConfigurationChanges= ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           // RequestedOrientation = ScreenOrientation.Portrait;
            //if (Device.Idiom == TargetIdiom.Phone)
            //{
            //    RequestedOrientation = ScreenOrientation.Portrait;
            //}
            //else
            //{
            //    RequestedOrientation = ScreenOrientation.SensorLandscape;
            //}
        }
        protected override void OnResume()
        {
            base.OnResume();
            StartActivity(typeof(MainActivity));
        }
    }
}