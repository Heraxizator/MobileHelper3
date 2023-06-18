using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class FutureViewModel : BaseViewModel
    {
        public FutureViewModel()
        {

        }

        public FutureViewModel(INavigation navigation)
        {
            Title = "Техника";
            Info = "У нашей психики есть одно замечательное свойство: чем меньше и дальше объект, тем меньше его значение. Если что-то для нас не важно, то это нас не беспокоит. Маленькая точка всегда меньше привлекает, чем что-то крупная. Поэтому одним из верных способов решить эмоцинальную проблему является механическое понижение её важности с помощью воображаемого отдаления и уменьшения. Всё просто до безобразия!";
            Navigation = navigation;
            Finish = new Command(ToFinish);
            Theory = new Command(ToFinish);
        }

    }
}
