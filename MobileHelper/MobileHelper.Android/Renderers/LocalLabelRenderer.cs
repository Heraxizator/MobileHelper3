using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileHelper;
using MobileHelper.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(LocalLabelRenderer))]
namespace MobileHelper.Droid.Renderers
{
    public class LocalLabelRenderer : LabelRenderer
    {

        public LocalLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var el = (Element as ExtendedLabel);

            if (el != null && el.JustifyText)
            {
                if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
                {
                    Control.JustificationMode = Android.Text.JustificationMode.InterWord;
                }

            }
        }
    }
}