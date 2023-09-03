using MobileHelper.Models.Items;
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
    public partial class PhysicsSearchPage : ContentPage
    {
        PhysicsSearchViewModel ViewModel { get; set; }
        public PhysicsSearchPage()
        {
            InitializeComponent();

            BindingContext = new PhysicsSearchViewModel(Navigation);

            ViewModel = BindingContext as PhysicsSearchViewModel;
        }

        private void LocalEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = e.NewTextValue;

            ViewModel.ExecuteSearch(text);
        }
    }
}