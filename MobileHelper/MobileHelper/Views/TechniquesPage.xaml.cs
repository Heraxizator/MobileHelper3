using MobileHelper.ViewModels.TechniqueViewModels;

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

            this.BindingContext = new TechniquesViewModel(this.Navigation);

            this.viewModel = this.BindingContext as TechniquesViewModel;
        }
    }
}