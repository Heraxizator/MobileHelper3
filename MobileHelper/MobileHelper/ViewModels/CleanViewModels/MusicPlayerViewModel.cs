using MobileHelper.Models.Tables;
using MobileHelper.Views.CleanPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.CleanViewModels
{
    public class MusicPlayerViewModel : BaseViewModel
    {
        public ObservableCollection<audio> AudioItems { get; set; }

        public MusicPlayerViewModel()
        {
            this.Title = "Очиститель";

            this.AudioItems = new ObservableCollection<audio>();

            Init();
        }

        private void Init()
        {
            AudioItems = new ObservableCollection<audio>()
            {
                new audio
                {
                    Name = "Псалом 19",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/029-kafizma-3_019.mp3",
                    Loading = false
                },

                new audio
                {
                    Name = "Псалом 22",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/032-kafizma-3_022.mp3",
                    Loading = false
                },

                new audio
                {
                    Name = "Псалом 26",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/039-kafizma-4_026.mp3",
                    Loading = false
                },

                new audio
                {
                    Name = "Псалом 33",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/049-kafizma-5_033.mp3",
                    Loading = false
                },

                new audio 
                {
                    Name = "Псалом 50",
                    Description = "Очищение от бесов",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/072-kafizma-7_050.mp3",
                    Loading = false
                },

                new audio 
                {
                    Name = "Псалом 90",
                    Description = "Господи, помилуй",
                    File = "https://azbyka.ru/audio/audio1/Svjashhennoe_pisanie/psaltir_valaam/127-kafizma-12_090.mp3",
                    Loading = false
                },
            };
        }
    }
}
