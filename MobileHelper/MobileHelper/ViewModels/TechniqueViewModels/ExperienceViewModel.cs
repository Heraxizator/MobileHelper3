using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class ExperienceViewModel : BaseViewModel
    {

        public ExperienceViewModel()
        {

        }

        public ExperienceViewModel(INavigation navigation)
        {
            Title = "Техника";
            Navigation = navigation;
            Finish = new Command(ToFinish);
            Theory = new Command(ToTheory);
            Info = "Техника модификации опыта (ТМО) — это эффективный инструмент психологической помощи, позволяющий разобраться как с устоявшимися, так и с недавно появившимися ограничениями, убеждениями, моделями поведения в различных ситуациях. ТМО подходит для самокоучинга. Суть ТМО — позитивное перепроживание ситуаций, давших вам негативный опыт.";
        }

    }
}
