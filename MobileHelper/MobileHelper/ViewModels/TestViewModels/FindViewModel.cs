using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TestViewModels
{
    public class FindViewModel : BaseViewModel
    {
        public ICommand Continue { get; set; }
        public FindViewModel()
        {

        }

        public FindViewModel(INavigation navigation)
        {
            Title = "Детектор";
            Navigation = navigation;
            Continue = new Command(ToContinue);
        }

        private async void ToContinue(object obj)
        {
            await Navigation.PushAsync(new TestPage());
        }
    }
}
