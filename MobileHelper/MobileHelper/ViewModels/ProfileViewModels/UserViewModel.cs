using MobileHelper.Models.Items;
using System.Collections.ObjectModel;

namespace MobileHelper.ViewModels.ProfileViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public ObservableCollection<technique> Techniques { get; set; }
        public ObservableCollection<Quots> Quots { get; set; }

        public UserViewModel()
        {
            this.Title = "Профиль";

            this.Techniques = new ObservableCollection<technique>()
            {
                new technique
                {
                    Title = "Лист бумаги",
                    Subtitle = "Быстрое очищение от негативных мыслей"
                },
                new technique
                {
                    Title = "50 лет спустя",
                    Subtitle = "Понижение важности за 10 секунд",
                },

                new technique
                {
                    Title = "Протокол Руби",
                    Subtitle = "Ликвидация любых привязанностей, зависимостей и привычек",
                },

                new technique
                {
                    Title = "Модификация опыта",
                    Subtitle = "Проработка ограничений, убеждений и моделей поведения",
                }
            };

            this.Quots = new ObservableCollection<Quots>()
            {
                new Quots
                {
                    Author = "Михаил Булгаков",
                    Text = "Что нужно для счастья? Только два, господа, только два: здоровое тело и спокойная душа."
                },

                new Quots
                {
                    Author = "Народная мудрость",
                    Text = "Лучше смерть, чем бесчестие."
                }

            };


        }
    }
}
