using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class SpinViewModel : BaseViewModel
    {
        public SpinViewModel()
        {

        }
        public SpinViewModel(INavigation navigation)
        {
            Title = "Техника";
            Info = "«Крутилка» Живорада Славинского - одна из самых тривиальных, но в тоже время действенных техник, которые только могут существовать. Она выполняется за считанные секунды, но результат ощущается уже спустя пару минут. Этот инструмент эффективен для снятия любого негативного заряда из прошлых эпизодов. Всё, что вам нужно, это определить болезненный эпизод и оценить то чувство, которое с ним связано по 10-балльной шкале. Всё гениальное просто!";
            Navigation = navigation;

            Finish = new Command(ToFinish);
            Theory = new Command(ToTheory);
        }

    }
}
