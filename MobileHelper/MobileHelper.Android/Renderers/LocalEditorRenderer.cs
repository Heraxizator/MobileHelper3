using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MobileHelper.Droid.Renderers;
using MobileHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidX.Core.Content;

[assembly: ExportRenderer(typeof(LocalEditor), typeof(LocalEditorRenderer))]
namespace MobileHelper.Droid.Renderers
{
    public class LocalEditorRenderer : EditorRenderer
    {

        public LocalEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                Control.TextCursorDrawable = ContextCompat.GetDrawable(Context, Resource.Color.colorAccent);
                Control.TextSize = 16;
                Control.SetPadding(0, 0, 0, 0);
            }
        }
    }
}