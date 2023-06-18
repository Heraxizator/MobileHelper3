using MobileHelper.ViewModels;
using MobileHelper.ViewModels.ConstructorViewModels;
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
    public partial class CreatedPage : ContentPage
    {
        public CreatedPage(int id)
        {
            InitializeComponent();
            BindingContext = new CreatedViewModel(Navigation, id);
        }
    }
}