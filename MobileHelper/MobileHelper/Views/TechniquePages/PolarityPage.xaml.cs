using MobileHelper.Models;
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
    public partial class PolarityPage : ContentPage
    {
        public PolarityPage()
        {
            InitializeComponent();
            BindingContext = new PolarityViewModel(Navigation);
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            var button = sender as ImageButton;

            var item = button.BindingContext as polarity;

            var vm = BindingContext as PolarityViewModel;

            vm.Delete.Execute(item);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as PolarityViewModel;

            Polarities.ScrollTo(vm.Polarity, ScrollToPosition.MakeVisible, true);
        }
    }
}