using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using MobileHelper;
using MobileHelper.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LocalEntry), typeof(LocalEntryRenderer))]
namespace MobileHelper.Droid.Renderers
{
    internal class LocalEntryRenderer : EntryRenderer
    {
        

        public LocalEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {

                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
                Control.TextCursorDrawable = ContextCompat.GetDrawable(Context, Resource.Color.colorAccent);
                Control.TextSize = 15;
                Control.SetPadding(0, 0, 0, 0);

                /*
                Control.Background = ContextCompat.GetDrawable(Context, Resource.Drawable.gray_entry);
                Control.TextCursorDrawable = ContextCompat.GetDrawable(Context, Resource.Color.colorAccent);
                Control.TextSize = 15;


                this.EditText.FocusChange += (sender, e) => {
                    bool hasFocus = e.HasFocus;
                    if (hasFocus)
                    {
                        Control.Background = ContextCompat.GetDrawable(Context, Resource.Drawable.blue_entry);
                    }
                    else
                    {
                        Control.Background = ContextCompat.GetDrawable(Context, Resource.Drawable.gray_entry);
                    }
                };
                */
            }
        }

        
    }
}