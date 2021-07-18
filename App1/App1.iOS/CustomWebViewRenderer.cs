using App1;
using App1.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomWebView), typeof(CustomWebViewRenderer))]

namespace App1.iOS
{
   public class CustomWebViewRenderer : WkWebViewRenderer
    {

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (NativeView != null && e.NewElement != null)
            {
                var webView = NativeView as UIWebView;

                if (webView == null)
                    return;

                webView.ScalesPageToFit = true;
                
            }
        }
    }
}