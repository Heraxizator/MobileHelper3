using MobileHelper.ViewModels;
using MobileHelper.ViewModels.TestViewModels;
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
    public partial class FindPage : ContentPage
    {
        public FindPage()
        {
            InitializeComponent();
            BindingContext = new FindViewModel(Navigation);
        }
    }
}