using Android.Animation;
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

[assembly: ExportRenderer(typeof(LocalFrame), typeof(LocalFrameRenderer))]
namespace MobileHelper.Droid.Renderers
{
    public class LocalFrameRenderer : FrameRenderer
    {

        public LocalFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            OSAppTheme currentTheme = Xamarin.Forms.Application.Current.RequestedTheme;
            if (e.NewElement != null)
            {
                
                if (currentTheme == OSAppTheme.Light)
                {
                    ViewGroup.SetBackgroundResource(Resource.Drawable.shadow);
                }
                else
                {
                    ViewGroup.SetBackgroundResource(Resource.Drawable.line);
                }
                
                //ViewGroup.SetBackgroundResource(Resource.Drawable.shadow);
            }
        }
    }
}