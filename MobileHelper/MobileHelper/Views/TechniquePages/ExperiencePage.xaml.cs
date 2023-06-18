using MobileHelper.ViewModels;
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
    public partial class ExperiencePage : ContentPage
    {
        public ExperiencePage()
        {
            InitializeComponent();
            BindingContext = new ExperienceViewModel(Navigation);
        }
    }
}