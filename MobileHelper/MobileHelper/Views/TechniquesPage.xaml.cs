using MobileHelper.ViewModels.TechniqueViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechniquesPage : ContentPage
    {
        private readonly TechniquesViewModel viewModel;
        public TechniquesPage()
        {
            InitializeComponent();
            this.BindingContext = new TechniquesViewModel();
            this.viewModel = this.BindingContext as TechniquesViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            int index = e.ItemIndex;

            switch (index)
            {
                case 0:
                    _ = this.Navigation.PushAsync(new SpinPage());
                    break;
                case 1:
                    _ = this.Navigation.PushAsync(new ComparisonPage());
                    break;
                case 2:
                    _ = this.Navigation.PushAsync(new PolarityPage());
                    break;
                case 3:
                    _ = this.Navigation.PushAsync(new PaperPage());
                    break;
                case 4:
                    _ = this.Navigation.PushAsync(new FuturePage());
                    break;
                case 5:
                    _ = this.Navigation.PushAsync(new HackPage());
                    break;
                case 6:
                    _ = this.Navigation.PushAsync(new ExperiencePage());
                    break;

                default:
                    _ = this.Navigation.PushAsync(new CreatedPage(index - 7));
                    break;

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new DesignerPage(-1));
        }

    }
}