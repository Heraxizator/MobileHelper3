using MobileHelper.Services;
using MobileHelper.ViewModels;
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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.BindingContext = new MainViewModel();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PushAsync(new UserPage(), false);
        }
    }
}