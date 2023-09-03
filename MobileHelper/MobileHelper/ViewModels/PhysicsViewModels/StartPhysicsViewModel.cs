using MobileHelper.Views.PhysicsPages;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.PhysicsViewModels
{
    public class StartPhysicsViewModel : BaseViewModel
    {
        public ICommand Continue { get; set; }
        public StartPhysicsViewModel(INavigation navigation)
        {
            this.Title = "Психосоматик";

            this.Navigation = navigation;

            this.Continue = new Command(async () => await this.Navigation.PushAsync(new PhysicsSearchPage()));
        }

        public StartPhysicsViewModel()
        {

        }
    }
}
