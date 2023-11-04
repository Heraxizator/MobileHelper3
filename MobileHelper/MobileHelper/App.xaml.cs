
using MobileHelper.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Application = Xamarin.Forms.Application;

namespace MobileHelper
{
    public partial class App : Application
    {

        public App()
        {
            Init();

            InitializeComponent();

            this.MainPage = new AppShell();

        }

        private void Init()
        {
            string theme = Preferences.Get("Theme", "Светлая");

            switch (theme)
            {
                case "Светлая":
                    Application.Current.UserAppTheme = OSAppTheme.Light;

                    break;
                case "Тёмная":
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
