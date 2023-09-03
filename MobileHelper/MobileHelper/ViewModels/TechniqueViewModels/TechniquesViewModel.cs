using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.ViewModels.ConstructorViewModels;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class TechniquesViewModel : BaseViewModel
    {
        public ObservableCollection<technique> techniques { get; set; }

        private readonly int base_count = 7;

        private const string image = "technique.png";
        private SqliteDB DBHelper { get; set; }
        public TechniquesViewModel()
        {
            this.Title = "Список техник";

            Init();

            MessagingCenter.Subscribe<DesignerViewModel, Technique>(this, "add", (sender, item) => this.techniques.Add(ParseFromDB(item)));

            MessagingCenter.Subscribe<CreatedViewModel, int>(this, "remove", (sender, id) => this.techniques.RemoveAt(this.base_count + id));

            MessagingCenter.Subscribe<DesignerViewModel, (Technique, int)>(this, "change", (sender, couple) =>
            {
                Technique item = couple.Item1;
                int id = couple.Item2;
                this.techniques[this.base_count + id] = ParseFromDB(item);
            });
        }

        public async void Init()
        {
            this.DBHelper = new SqliteDB();

            this.techniques = new ObservableCollection<technique>()
            {
                new technique
                {
                    Id = "Техника №1",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Крутилка",
                    Subtitle = "Метод мгновенной нейтрализации травм и шоков",
                    Theme = "Эпизоды",
                    Author = "Живорад Славинский"
                },

                new technique
                {
                    Id = "Техника №2",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Сравнение важностей",
                    Subtitle = "Прошлое, настоящее и будущее",
                    Theme = "Важность",
                    Author = "НЛП"
                },
                new technique
                {
                    Id = "Техника №3",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Полярности",
                    Subtitle = "Работа с противоположными аспектами",
                    Theme = "Аспекты",
                    Author = "Живорад Славинский"
                },
                new technique
                {
                    Id = "Техника №4",
                    Date="26.01.2023",
                    Image = image,
                    Title = "Лист бумаги",
                    Subtitle = "Быстрое очищение от негативных мыслей",
                    Theme = "Мысли",
                    Author = "Психика"
                },
                new technique
                {
                    Id = "Техника №5",
                    Date="30.01.2023",
                    Image = image,
                    Title = "50 лет спустя",
                    Subtitle = "Понижение важности за 10 секунд",
                    Theme = "Важность",
                    Author = "НЛП"
                },

                new technique
                {
                    Id = "Техника №6",
                    Date="30.01.2023",
                    Image = image,
                    Title = "Протокол Руби",
                    Subtitle = "Ликвидация любых привязанностей, зависимостей и привычек",
                    Theme = "Обработчик",
                    Author = "Турбо-Суслик"
                },

                new technique
                {
                    Id = "Техника №7",
                    Date="08.02.2023",
                    Image = image,
                    Title = "Модификация опыта",
                    Subtitle = "Проработка ограничений, убеждений и моделей поведения",
                    Theme = "Эпизоды",
                    Author = "Филипп Славинский"
                }
            };

            System.Collections.Generic.List<Technique> list = await this.DBHelper.GetListAsync<Technique>();

            if (list.Count > 0)
            {
                foreach (Technique item in list)
                {
                    this.techniques.Add(ParseFromDB(item));
                }
            }


        }

        private technique ParseFromDB(Technique item)
        {
            return new technique
            {
                Id = "Техника №" + (this.techniques.Count + 1),
                Date = item.Date,
                Image = item.Path,
                Title = item.Name,
                Subtitle = item.Describtion,
                Theme = item.Theme,
                Author = item.Author,


            };
        }


    }
}