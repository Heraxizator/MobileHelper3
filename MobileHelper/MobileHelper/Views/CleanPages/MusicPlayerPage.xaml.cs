using MediaManager;
using MobileHelper.Models.Tables;
using MobileHelper.ViewModels.CleanViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHelper.Views.CleanPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayerPage : ContentPage
    {
        public MusicPlayerPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item as audio;

            var file = item.File;

            if (CrossMediaManager.Current.IsPlaying())
            {
                CrossMediaManager.Current.Stop();
            }

            else
            {
                CrossMediaManager.Current.Play(file);

            }
        }
    }
}