using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TechniqueViewModels
{
    public class TheoryViewModel : BaseViewModel
    {
        private string text { get; set; }
        public TheoryViewModel()
        {

        }

        public TheoryViewModel(string content)
        {
            Title = "Теория";
            Text = content;

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
    }
}
