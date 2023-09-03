using MobileHelper.Models.DataItems;
using System.Collections.ObjectModel;

namespace MobileHelper.ViewModels.CleanViewModels
{
    public class MusicPlayerViewModel : BaseViewModel
    {
        public ObservableCollection<Audio> AudioItems { get; set; }

        public MusicPlayerViewModel()
        {
            this.Title = "Очиститель";

            this.AudioItems = new ObservableCollection<Audio>();

            Init();
        }

        private void Init()
        {
            this.AudioItems = new ObservableCollection<Audio>()
            {
                new Audio
                {
                    Name = "Псалом 19",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/029-kafizma-3_019.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 22",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/032-kafizma-3_022.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 26",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/039-kafizma-4_026.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 33",
                    Description = "Любовь к Господу",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/049-kafizma-5_033.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 50",
                    Description = "Очищение от бесов",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/072-kafizma-7_050.mp3",
                    Loading = false
                },

                new Audio
                {
                    Name = "Псалом 90",
                    Description = "Господи, помилуй",
                    File = "https://azbyka.ru/Audio/Audio1/Svjashhennoe_pisanie/psaltir_valaam/127-kafizma-12_090.mp3",
                    Loading = false
                },
            };
        }
    }
}
