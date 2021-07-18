using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Plugin.PushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App1.Droid
{
    [Application]
    public class MainApplication : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                PushNotificationManager.DefaultNotificationChannelId = "DefaultChannel";

                //Change for your default notification channel name here
                PushNotificationManager.DefaultNotificationChannelName = "General";
            }

            //If debug you should reset the token each time.
#if DEBUG
            PushNotificationManager.Initialize(this, true);
#else
            PushNotificationManager.Initialize(this, false);
#endif

            PushNotificationManager.IconResource = Resource.Drawable.IconNotify;
            
            //Handle notification when app is closed here
            CrossPushNotification.Current.OnNotificationReceived += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine($"received");
                if (p.Data.ContainsKey("body"))
                {
                    SendNotification(p.Data["body"].ToString(), p.Data);
                    //SetMessageText($"{p.Data["body"]}");
                }

            };
        }
        void SendNotification(string messageBody, IDictionary<string, object> data)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            foreach (var key in data.Keys)
            {
                intent.PutExtra(key, (string)data[key]);
            }

            var pendingIntent = PendingIntent.GetActivity(this,
                                                          100,
                                                          intent,
                                                          PendingIntentFlags.OneShot);

            var notificationBuilder = new NotificationCompat.Builder(this, "default")
                                      .SetSmallIcon(Resource.Drawable.IconNotify)
                                      .SetContentTitle("@string/my_name")
                                      .SetContentText(messageBody)
                                      .SetAutoCancel(true)
                                      .SetContentIntent(pendingIntent)
                                      .SetVibrate(new long[] { 500, 500, 500, 500 })
                                      .SetDefaults(Convert.ToInt32(NotificationDefaults.Sound));

            var notificationManager = NotificationManagerCompat.From(this);
            notificationManager.Notify(100, notificationBuilder.Build());
        }
        
    }
}