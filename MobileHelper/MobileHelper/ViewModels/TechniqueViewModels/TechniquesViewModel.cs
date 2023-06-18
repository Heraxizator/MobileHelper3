using MobileHelper.Models;
using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.ViewModels.ConstructorViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHelper.ViewModels
{
    public class TechniquesViewModel : BaseViewModel
    {
        public ObservableCollection<technique> techniques { get; set; }

        private readonly int base_count = 7;

        private const string image = "technique.png";
        private SqliteDB DBHelper { get; set; }
        public TechniquesViewModel()
        {
            Title = "Список техник";

            Init();

            MessagingCenter.Subscribe<DesignerViewModel, Technique>(this, "add", (sender, item) =>
            {

                techniques.Add(ParseFromDB(item));
                
            });

            MessagingCenter.Subscribe<CreatedViewModel, int>(this, "remove", (sender, id) =>
            {
                techniques.RemoveAt(this.base_count + id);
            });

            MessagingCenter.Subscribe<DesignerViewModel, (Technique, int)>(this, "change", (sender, couple) =>
            {
                var item = couple.Item1;
                var id = couple.Item2;
                techniques[this.base_count + id] = ParseFromDB(item);
            });
        }

        public async void Init()
        {
            DBHelper = new SqliteDB();

            techniques = new ObservableCollection<technique>()
            {
                new technique
                {
                    id = "Техника №1",
                    date="26.01.2023",
                    image = image,
                    title = "Крутилка",
                    subtitle = "Метод мгновенной нейтрализации травм и шоков",
                    theme = "Эпизоды",
                    author = "Живорад Славинский"
                },

                new technique
                {
                    id = "Техника №2",
                    date="26.01.2023",
                    image = image,
                    title = "Сравнение важностей",
                    subtitle = "Прошлое, настоящее и будущее",
                    theme = "Важность",
                    author = "НЛП"
                },
                new technique
                {
                    id = "Техника №3",
                    date="26.01.2023",
                    image = image,
                    title = "Полярности",
                    subtitle = "Работа с противоположными аспектами",
                    theme = "Аспекты",
                    author = "Живорад Славинский"
                },
                new technique
                {
                    id = "Техника №4",
                    date="26.01.2023",
                    image = image,
                    title = "Лист бумаги",
                    subtitle = "Быстрое очищение от негативных мыслей",
                    theme = "Мысли",
                    author = "Психика"
                },
                new technique
                {
                    id = "Техника №5",
                    date="30.01.2023",
                    image = image,
                    title = "50 лет спустя",
                    subtitle = "Понижение важности за 10 секунд",
                    theme = "Важность",
                    author = "НЛП"
                },

                new technique
                {
                    id = "Техника №6",
                    date="30.01.2023",
                    image = image,
                    title = "Протокол Руби",
                    subtitle = "Ликвидация любых привязанностей, зависимостей и привычек",
                    theme = "Обработчик",
                    author = "Турбо-Суслик"
                },

                new technique
                {
                    id = "Техника №7",
                    date="08.02.2023",
                    image = image,
                    title = "Модификация опыта",
                    subtitle = "Проработка ограничений, убеждений и моделей поведения",
                    theme = "Эпизоды",
                    author = "Филипп Славинский"
                }
            };

            var list = await DBHelper.GetListAsync<Technique>();

            if (list.Count > 0)
            {
                foreach (Technique item in list)
                {
                    techniques.Add(ParseFromDB(item));
                }
            }

            
        }

        private technique ParseFromDB(Technique item)
        {
            return new technique
            {
                id = "Техника №" + (techniques.Count + 1),
                date = item.Date,
                image = item.Path,
                title = item.Name,
                subtitle = item.Describtion,
                theme = item.Theme,
                author = item.Author,


            };
        }

   
    }
}