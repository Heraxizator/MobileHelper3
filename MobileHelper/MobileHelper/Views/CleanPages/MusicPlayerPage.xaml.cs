using MediaManager;
using MobileHelper.Models.DataItems;

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
            Audio item = e.Item as Audio;

            string file = item.File;

            if (CrossMediaManager.Current.IsPlaying())
            {
                _ = CrossMediaManager.Current.Stop();
            }

            else
            {
                _ = CrossMediaManager.Current.Play(file);

            }
        }
    }
}