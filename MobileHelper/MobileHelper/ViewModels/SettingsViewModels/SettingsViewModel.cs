using MobileHelper.Services;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.SettingsViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        private DialogService dialog { get; set; }
        public string theme { get; set; }
        public string color { get; set; }
        public string form { get; set; }
        public string size { get; set; }
        public bool isThick { get; set; }
        public SettingsViewModel()
        {

        }
        public SettingsViewModel(INavigation navigation)
        {
            Title = "Настройки";
            Navigation = navigation;
            Finish = new Command(ToEnd);
            dialog = DependencyService.Get<DialogService>();
        }

        private async void ToEnd(object obj)
        {
            await dialog.ShowAsync("Mobile Helper", "Изменения будут применены при следующем запуске приложения");

            Preferences.Set("Theme", Theme);
            Preferences.Set("Color", Color);
            Preferences.Set("Form", Form);
            Preferences.Set("Size", Size);
            Preferences.Set("IsBold", IsThick);

        }

        public string Theme
        {
            get => theme;
            set
            {
                if (theme != value)
                {
                    theme = value;
                    OnPropertyChanged(nameof(Theme));
                }
            }
        }

        public string Color
        {
            get => color;
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(nameof(Color));
                }
            }
        }

        public string Form
        {
            get => form;
            set
            {
                if (form != value)
                {
                    form = value;
                    OnPropertyChanged(nameof(Form));
                }
            }
        }

        public string Size
        {
            get => size;
            set
            {
                if (size != value)
                {
                    size = value;
                    OnPropertyChanged(nameof(Size));
                }
            }
        }

        public bool IsThick
        {
            get => isThick;
            set
            {
                if (isThick != value)
                {
                    isThick = value;
                    OnPropertyChanged(nameof(IsThick));
                }
            }
        }
    }
}
