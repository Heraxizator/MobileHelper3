using MobileHelper.Models.Tables;
using MobileHelper.ViewModels.ConstructorViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHelper.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DesignerPage : ContentPage
    {
        public DesignerPage(int id)
        {
            InitializeComponent();
            this.BindingContext = new DesignerViewModel(this.Navigation, id);
        }

    }
}