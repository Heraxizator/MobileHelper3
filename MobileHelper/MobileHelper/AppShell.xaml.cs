using MobileHelper.Services;
using MobileHelper.ViewModels;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MobileHelper
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            DBHelper.Init();
        }
    }
}
