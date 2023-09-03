using MobileHelper.Models.Tables;
using MobileHelper.Services;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.ConstructorViewModels
{
    public class DesignerViewModel : BaseViewModel
    {
        public new INavigation Navigation { get; set; }
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
            this.Navigation = navigation;
            this.Title = "Конструктор";
            this.LoadImage = new Command(ToLoadImage);
            this.DBHelper = new SqliteDB();
            this.Path = "technique.png";
            this.currentId = id;


            Init();
        }
        private async void Init()
        {

            if (this.currentId != -1)
            {
                this.Aim = "Изменить";
                this.currentItem = await this.DBHelper.GetElementById<Technique>(this.currentId);
                this.Name = this.currentItem.Name;
                this.Description = this.currentItem.Describtion;
                this.Theme = this.currentItem.Theme;
                this.Author = this.currentItem.Author;
                this.Algorithm = this.currentItem.Algorithm;
                this.Path = this.currentItem.Path;
                this.ExecuteTechnique = new Command(ToChangeTechnique);
            }

            else
            {
                this.Aim = "Добавить";
                this.ExecuteTechnique = new Command(ToAddTechnique);

            }
        }

        private async void ToLoadImage(object obj)
        {

            FileResult photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                this.Path = photo.FullPath;

            }
        }

        private async void ToChangeTechnique(object obj)
        {
            List<Technique> list = await this.DBHelper.GetListAsync<Technique>();

            Technique item = new Technique
            {
                Name = this.Name,
                Describtion = this.Description,
                Theme = this.Theme,
                Author = this.Author,
                Algorithm = this.Algorithm,
                Path = this.Path
            };

            list[this.currentId] = item;

            await this.DBHelper.DeleteAllAsync<Technique>();
            await this.DBHelper.InsertAllAsync(list);

            MessagingCenter.Send(this, "change", (this.currentItem, this.currentId));
            await this.Navigation.PushAsync(new TechniquesPage());


        }
        private async void ToAddTechnique(object obj)
        {
            if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Description) && !string.IsNullOrEmpty(this.Theme)
                && !string.IsNullOrEmpty(this.Author) && !string.IsNullOrEmpty(this.Algorithm))
            {
                Technique technique = new Technique
                {
                    Id = await this.DBHelper.GetCountAsync<Technique>(),
                    Date = DateTime.Now.ToString().Split(' ').First(),
                    Name = this.Name,
                    Describtion = this.Description,
                    Theme = this.Theme,
                    Author = this.Author,
                    Algorithm = this.Algorithm,
                    Path = this.Path,
                };

                await this.DBHelper.InsertAsync(technique);

                _ = await this.Navigation.PopAsync();

                MessagingCenter.Send(this, "add", technique);
            }

        }

        public string Name
        {
            get => this.name;
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    OnPropertyChanged(nameof(this.Name));
                }
            }
        }

        public string Description
        {
            get => this.describtion;
            set
            {
                if (this.describtion != value)
                {
                    this.describtion = value;
                    OnPropertyChanged(nameof(this.Description));
                }
            }
        }

        public string Theme
        {
            get => this.theme;
            set
            {
                if (this.theme != value)
                {
                    this.theme = value;
                    OnPropertyChanged(nameof(this.Theme));
                }
            }
        }

        public string Author
        {
            get => this.author;
            set
            {
                if (this.author != value)
                {
                    this.author = value;
                    OnPropertyChanged(nameof(this.Author));
                }
            }
        }

        public string Algorithm
        {
            get => this.algorithm;
            set
            {
                if (this.author != value)
                {
                    this.algorithm = value;
                    OnPropertyChanged(nameof(this.Algorithm));
                }
            }
        }

        public string Path
        {
            get => this.path;
            set
            {
                if (this.path != value)
                {
                    this.path = value;
                    OnPropertyChanged(nameof(this.Path));
                }
            }
        }

        public string Aim
        {
            get => this.aim;
            set
            {
                if (this.aim != value)
                {
                    this.aim = value;
                    OnPropertyChanged(nameof(this.Aim));
                }
            }
        }
    }
}
