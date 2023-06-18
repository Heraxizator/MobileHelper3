using MobileHelper.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MobileHelper.ViewModels.ProfileViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public ObservableCollection<technique> techniques { get; set; }
        public ObservableCollection<quots> quots { get; set; }

        public UserViewModel()
        {
            Title = "Профиль";

            techniques = new ObservableCollection<technique>()
            {
                new technique
                {
                    title = "Лист бумаги",
                    subtitle = "Быстрое очищение от негативных мыслей"
                },
                new technique
                {
                    title = "50 лет спустя",
                    subtitle = "Понижение важности за 10 секунд",
                },

                new technique
                {
                    title = "Протокол Руби",
                    subtitle = "Ликвидация любых привязанностей, зависимостей и привычек",
                },

                new technique
                {
                    title = "Модификация опыта",
                    subtitle = "Проработка ограничений, убеждений и моделей поведения",
                }
            };

            quots = new ObservableCollection<quots>()
            {
                new quots
                {
                    Author = "Михаил Булгаков",
                    Text = "Что нужно для счастья? Только два, господа, только два: здоровое тело и спокойная душа."
                },

                new quots
                {
                    Author = "Народная мудрость",
                    Text = "Лучше смерть, чем бесчестие."
                }

            };


        }
    }
}
