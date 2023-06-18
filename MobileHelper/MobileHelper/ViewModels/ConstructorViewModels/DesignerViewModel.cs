using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.ConstructorViewModels
{
    public class DesignerViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand ExecuteTechnique { get; set; }
        public ICommand LoadImage { get; set; }
        private SqliteDB DBHelper { get; set; }
        private string name { get; set; }
        private string describtion { get; set; }
        private string theme { get; set; }
        private string author { get; set; }
        private string algorithm { get; set; }
        private string path { get; set; }
        private string aim { get; set; }
        private int currentId { get; set; }
        private Technique currentItem { get; set; }
        public DesignerViewModel()
        {

        }
        public DesignerViewModel(INavigation navigation, int id)
        {
            Navigation = navigation;
            Title = "Конструктор";
            LoadImage = new Command(ToLoadImage);
            DBHelper = new SqliteDB();
            Path = "technique.png";
            currentId = id;


            Init();
        }
        private async void Init()
        {

            if (currentId != -1)
            {
                Aim = "Изменить";
                currentItem = await DBHelper.GetElementById<Technique>(currentId);
                Name = currentItem.Name;
                Description = currentItem.Describtion;
                Theme = currentItem.Theme;
                Author = currentItem.Author;
                Algorithm = currentItem.Algorithm;
                Path = currentItem.Path;
                ExecuteTechnique = new Command(ToChangeTechnique);
            }

            else
            {
                Aim = "Добавить";
                ExecuteTechnique = new Command(ToAddTechnique);

            }
        }

        private async void ToLoadImage(object obj)
        {

            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                Path = photo.FullPath;

            }
        }

        private async void ToChangeTechnique(object obj)
        {
            var list = await DBHelper.GetListAsync<Technique>();

            var item = new Technique
            {
                Name = Name,
                Describtion = Description,
                Theme = Theme,
                Author = Author,
                Algorithm = Algorithm,
                Path = Path
            };

            list[currentId] = item;

            await DBHelper.DeleteAllAsync<Technique>();
            await DBHelper.InsertAllAsync(list);

            MessagingCenter.Send(this, "change", (currentItem, currentId));
            await Navigation.PushAsync(new TechniquesPage());


        }
        private async void ToAddTechnique(object obj)
        {
            if (!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Description) && !string.IsNullOrEmpty(Theme)
                && !string.IsNullOrEmpty(Author) && !string.IsNullOrEmpty(Algorithm))
            {
                Technique technique = new Technique
                {
                    Id = await DBHelper.GetCountAsync<Technique>(),
                    Date = DateTime.Now.ToString().Split(' ').First(),
                    Name = Name,
                    Describtion = Description,
                    Theme = Theme,
                    Author = Author,
                    Algorithm = Algorithm,
                    Path = Path,
                };

                await DBHelper.InsertAsync(technique);

                await Navigation.PopAsync();

                MessagingCenter.Send(this, "add", technique);
            }

        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Description
        {
            get => describtion;
            set
            {
                if (describtion != value)
                {
                    describtion = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        public string Theme
        {
            get => theme;
            set
            {
                if (theme != value)
                {
                    theme = value;
                    OnPropertyChanged(nameof(Theme));
                }
            }
        }

        public string Author
        {
            get => author;
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged(nameof(Author));
                }
            }
        }

        public string Algorithm
        {
            get => algorithm;
            set
            {
                if (author != value)
                {
                    algorithm = value;
                    OnPropertyChanged(nameof(Algorithm));
                }
            }
        }

        public string Path
        {
            get => path;
            set
            {
                if (path != value)
                {
                    path = value;
                    OnPropertyChanged(nameof(Path));
                }
            }
        }

        public string Aim
        {
            get => aim;
            set
            {
                if (aim != value)
                {
                    aim = value;
                    OnPropertyChanged(nameof(Aim));
                }
            }
        }
    }
}
