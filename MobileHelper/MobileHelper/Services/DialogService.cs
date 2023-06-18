using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelper.Services
{
    public class DialogService : IDialog
    {
        public async Task ShowAsync(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
            
        }
    }
}
