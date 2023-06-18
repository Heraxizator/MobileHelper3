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
    public class PolarityViewModel : BaseViewModel
    {
        public ICommand Add { get; set; }
        public string positive { get; set; }
        public string negative { get; set; }
        public bool isFull { get; set; }
        public polarity polarity { get; set; }
        public ObservableCollection<polarity> polarities { get; set; }
        public PolarityViewModel()
        {

        }

        public PolarityViewModel(INavigation navigation)
        {
            Title = "Техника";
            Info = "Любой внутренний конфликт связан с борьбой двух противоположных мотивов, желаний, убеждений или целей. По сути причиной многих духовных проблем являются дуальности. Поэтому работа с полярностями - ещё один путь к освобождению от того, что беспокоит. Но, как правило, далеко не одна пара дуальностей создаёт внутренний конфликт. Их может быть несколько. По этой причине рекомендуется рассматривать побольше возможных пар, связанных с проблемой.";
            IsFull = false;
            Navigation = navigation;
            Finish = new Command(ToFinish);
            polarities = new ObservableCollection<polarity>();
            Add = new Command(ToAdd);
            Theory = new Command(ToTheory);

        }

        public Command<polarity> Delete
        {
            get
            {
                return new Command<polarity>((item) =>
                {
                    polarities.Remove(item);
                    if (polarities.Count == 0)
                    {
                        IsFull = false;
                    }
                });
            }
        }

        private void ToAdd(object obj)
        {
            if (!string.IsNullOrEmpty(Negative) && !string.IsNullOrEmpty(Positive))
            {
                IsFull = true;
                polarity item = new polarity { id = "Пара №" + (polarities.Count + 1), positive = Positive, negative = Negative };
                polarities.Add(item);
                Polarity = item;

                Negative = "";
                Positive = "";
            }

        }

        public string Positive
        {
            get => positive;
            set
            {
                if (positive != value)
                {
                    positive = value;
                    OnPropertyChanged(nameof(Positive));
                }
            }
        }

        public string Negative
        {
            get => negative;
            set
            {
                if (negative != value)
                {
                    negative = value;
                    OnPropertyChanged(nameof(Negative));
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

        public polarity Polarity
        {
            get => polarity;
            set
            {
                if (polarity != value)
                {
                    polarity = value;
                    OnPropertyChanged(nameof(Polarity));
                }
            }
        }
    }
}
