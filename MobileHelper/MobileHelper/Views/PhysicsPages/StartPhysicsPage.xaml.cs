using MobileHelper.ViewModels.PhysicsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileHelper.Views.PhysicsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StartPhysicsPage : ContentPage
    {
        public StartPhysicsPage()
        {
            InitializeComponent();

            BindingContext = new StartPhysicsViewModel(Navigation);
        }
    }
}