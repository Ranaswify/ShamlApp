using Plugin.Multilingual;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        string url;
        public MainPage()
        {
            InitializeComponent();

            var deviceCuluture = CrossMultilingual.Current.DeviceCultureInfo;

            if (deviceCuluture.Name == "en-US")
            {
                url= "https://shaaml.com/";
            }
            else
            {
                url = "https://shaaml.com/";
            }
            webPage.Source = url;

        }

        void webviewNavigating(object sender, WebNavigatingEventArgs e)
        {
            labelLoading.IsVisible = true;
            labelLoading.IsRunning = true;
            labelLoadingText.IsVisible = true;
            webPage.IsVisible = false;
            
        }
        
        void webviewNavigated(object sender, WebNavigatedEventArgs e)
        {
            labelLoading.IsVisible = false;
            labelLoading.IsRunning = false;
            labelLoadingText.IsVisible = false;
            stack.IsVisible = false;
            webPage.IsVisible = true;
      
        }
    }
}
