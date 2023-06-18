using MobileHelper.ViewModels;
using MobileHelper.ViewModels.TechniqueViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TechniquesPage : ContentPage
    {
        private TechniquesViewModel viewModel;
        public TechniquesPage()
        {
            InitializeComponent();
            BindingContext = new TechniquesViewModel();
            viewModel = BindingContext as TechniquesViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var index = e.ItemIndex;

            switch (index)
            {
                case 0:
                    Navigation.PushAsync(new SpinPage());
                    break;
                case 1:
                    Navigation.PushAsync(new ComparisonPage());
                    break;
                case 2:
                    Navigation.PushAsync(new PolarityPage());
                    break;
                case 3:
                    Navigation.PushAsync(new PaperPage());
                    break;
                case 4:
                    Navigation.PushAsync(new FuturePage());
                    break;
                case 5:
                    Navigation.PushAsync(new HackPage());
                    break;
                case 6:
                    Navigation.PushAsync(new ExperiencePage());
                    break;

                default:
                    Navigation.PushAsync(new CreatedPage(index - 7));
                    break;

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DesignerPage(-1));
        }

    }
}