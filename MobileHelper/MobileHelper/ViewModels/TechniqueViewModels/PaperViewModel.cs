using MobileHelper.Models;
using MobileHelper.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class PaperViewModel : BaseViewModel
    {
        public string text { get; set; }
        public bool isFull { get; set; }
        public paper paper { get; set; }
        public ObservableCollection<paper> papers { get; set; }
        public Command Add { get; set; }
        public PaperViewModel()
        {

        }

        public PaperViewModel(INavigation navigation)
        {
            Title = "Техника";
            Info = "Учёные провели эксперимент и выявили одну замечательную закономерность: если взять лист бумаги, записать свои негативные мысли и выбросить этот лист, то тот негатив потеряют какое-либо значение для человека и перестанет его беспокоить. Но для такой практики совершенно необязательно тратить бумагу. Можно просто воспользоваться текстовым редактором на следующей странице. Техника проста до безобразия!";
            Navigation = navigation;
            Finish = new Command(ToFinish);
            Theory = new Command(ToTheory);
            papers = new ObservableCollection<paper>();
            Add = new Command(ToAdd);
        }

        private void ToAdd(object obj)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                IsFull = true;
                paper item = new paper { id = "Карточка №" + (papers.Count + 1), text = Text };
                papers.Add(item);
                Paper = item;

                Text = "";
            }

        }

        public Command<paper> Delete
        {
            get
            {
                return new Command<paper>((item) =>
                {
                    papers.Remove(item);
                    if (papers.Count == 0)
                    {
                        IsFull = false;
                    }
                });
            }
        }


        public string Text
        {
            get => text;
            set
            {
                if (text != value)
                {
                    text = value;
                    OnPropertyChanged(nameof(Text));
                }
            }
        }

        public bool IsFull
        {
            get => isFull;
            set
            {
                if (isFull != value)
                {
                    isFull = value;
                    OnPropertyChanged(nameof(IsFull));
                }
            }
        }
        public paper Paper
        {
            get => paper;
            set
            {
                if (paper != value)
                {
                    paper = value;
                    OnPropertyChanged(nameof(Paper));
                }
            }
        }
    }
}
