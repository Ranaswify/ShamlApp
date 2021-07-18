using Plugin.PushNotification;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
           
            // Handle when your app starts
            CrossPushNotification.Current.OnTokenRefresh += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"TOKEN REC: {p.Token}");
            
            };

            CrossPushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                
            };

            CrossPushNotification.Current.OnNotificationOpened += (s, p) =>
            {
              
            };
            CrossPushNotification.Current.OnNotificationDeleted += (s, p) =>
            {
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
