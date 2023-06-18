using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileHelper.ViewModels.TestViewModels
{
    public class TestViewModel : BaseViewModel
    {

        private const string firstInstruction = "Выберите приятный вам цвет";
        private const string secondInstruction = "А теперь выберите неприятный вам цвет";
        private string[] positiveValues { get; set; }
        private string[] negativeValues { get; set; }
        private string[] colorValues { get; set; }
        private string[] nameValues { get; set; }
        private int firstId { get; set; }
        private int secondId { get; set; }
        public ICommand Restart { get; set; }
        public ICommand BlackHandler { get; set; }
        public ICommand RedHandler { get; set; }
        public ICommand BlueHandler { get; set; }
        public ICommand PurpleHandler { get; set; }
        public ICommand YellowHandler { get; set; }
        public ICommand BrownHandler { get; set; }
        public ICommand GreenHandler { get; set; }
        public ICommand GrayHandler { get; set; }
        private string currentInstruction { get; set; }
        private string firstColor { get; set; }
        private string secondColor { get; set; }
        private string firstName { get; set; }
        private string secondName { get; set; }
        private string firstResult { get; set; }
        private string secondResult { get; set; }
        private bool isStart { get; set; }
        private bool isFinish { get; set; }
        private bool isBlack { get; set; }
        private bool isRed { get; set; }
        private bool isBlue { get; set; }
        private bool isPurple { get; set; }
        private bool isYellow { get; set; }
        private bool isBrown { get; set; }
        private bool isGreen { get; set; }
        private bool isGray { get; set; }
        public TestViewModel()
        {

        }

        public TestViewModel(INavigation navigation)
        {
            Title = "Тест";
            Navigation = navigation;

            Finish = new Command(ToFinish);
            Restart = new Command(ToRestart);
            BlackHandler = new Command(ToBlackHandler);
            RedHandler = new Command(ToRedHandler);
            BlueHandler = new Command(ToBlueHandler);
            PurpleHandler = new Command(ToPurpleHandler);
            YellowHandler = new Command(ToYellowCommand);
            BrownHandler = new Command(ToBrownHandler);
            GreenHandler = new Command(ToGreenHandler);
            GrayHandler = new Command(ToGrayHandler);

            positiveValues = new string[8] {
                "Негативизм, неприятие отказ от удовольствия и агрессия заполнили все Ваше сознание и тело. Вы враждебно настроены и можете взорваться яростью в любую минуту. Вы близки к разрушению себя или отношений.",
                "Сейчас Вы эмоционально возбуждены. Настроение приподнятое. Вы стремитесь к достижению, успеху. Вы наступаете, возможно излишне давите. Вы напористы, порой агрессивны.",
                "Вы стремитесь к согласию, доверию, пониманию, сочувствию. Сейчас Вы испытываете эмоциональный комфорт, спокойствие, мягкость, мечтательность. Вы расположены к общению с друзьями.",
                "Вы флиртуете направо и налево, стремитесь завести хоть какую-нибудь сексуальную интрижку. Вы стремитесь понравиться, получить поддержку или комплимент. Настроение ровное, но не спокойное.",
                "Оптимизм переполняет Вашу душу и заставляет сердце стучать быстрее. Вы расслаблены и полны мечтами об удаче. Вы готовы к изменениям, к полному освобождению от отношений или обязательств.",
                "Вы устали и стремитесь к отдыху и эмоциональной стабильности. Вы психологически устали и голодны по поддерживающим отношениям. Подспудно Вы чего-то боитесь и не чувствуете себя в безопасности. Вы нуждаетесь в чувственном удовлетворении.",
                "Вы уверены в себе, даже самоуверенны. Сейчас пик Вашей силы, самоуважения. Вы способны на многое и стремитесь захватить власть в общении. Взять верх над собеседниками. Возможно напротив, Вы заняли психологическую оборону.",
                "Вы сейчас в поисках плеча, на которое сможете опереться.Хотите спрятаться от всего тяжелого, что есть в Вашей жизни, обрести эмоциональный покой и пристанище. Вы мимикрируете и маскируете свои истинные чувства под маской деланного безразличия и безучастности."
            };

            negativeValues = new string[8] {
                 "Внешне Вы спокойны и уверены. Однако Вы просто загнали агрессию глубоко вовнутрь и перешли на рельсы отрицания и самобичевания.",
                 "Вы постоянно раздражены и перевозбуждены. Вы в глубоком стрессе. Иногда Вы словно обессилены или даже утомлены.",
                 "Вы беспокойны. Возможно недавно произошел разрыв близких отношений. Вы одиноки и расстроены.",
                 "Вы стремитесь быть незаметным и спрятаться от излишнего внимания. Скромность, контроль чувств и поведения присущи Вам именно сейчас.",
                 "Вы разочарованы вплоть до отчаяния. Вы недоверчивы и подозрительны. Вы мечетесь, эмоциональное состояние нестабильно: то подъем, то резкий спад.",
                 "Вы как натянутая струна. Вы отрицаете все свои эмоциональные и физические потребности.  Вы бежите от слабости,ограничивая себя во всем.",
                 "Вы фрустрированы недостатком внимания и уважения со стороны партнера. Вы унижены, обижены, уязвлены и обесточены.  У Вас не осталось сил на сопротивление.",
                 "Вы проактивны как никогда. Вы целиком включены в ситуацию «здесь-и-сейчас». Вы контакты, в меру веселы и находчивы. У Вас есть цель и Вы обретаете уверенное спокойствие в завтрашнем дне. Вы словно обрели цель."
            };

            colorValues = new string[8]
            {
                "Black", "Red", "Blue", "Purple", "Yellow", "Orange", "Green", "Gray"
            };

            nameValues = new string[8]
            {
                "Чёрный", "Красный", "Синий", "Фиолетовый", "Жёлтый", "Оранжевый", "Зелёный", "Серый"
            };

            Init();
        }

        private void ToRestart(object obj)
        {
            Init();
        }

        private void Init()
        {
            CurrentInstruction = firstInstruction;
            IsBlack = true;
            IsRed = true;
            IsBlue = true;
            IsPurple = true;
            IsYellow = true;
            IsBrown = true;
            IsGreen = true;
            IsGray = true;

            firstId = -1;
            secondId = -1;

            IsStart = true;
            IsFinish = false;
        }

        private void SaveResult(int id)
        {
            if (firstId == -1)
            {
                firstId = id;
                CurrentInstruction = secondInstruction;
                FirstResult = positiveValues[firstId];
                FirstColor = colorValues[firstId];
                FirstName = nameValues[firstId];
            }

            else if (secondId == -1)
            {
                secondId = id;
                SecondResult = negativeValues[secondId];
                SecondColor = colorValues[secondId];
                SecondName = nameValues[secondId];
                IsStart = false;
                IsFinish = true;
            }
        }

        private void ToGrayHandler(object obj)
        {
            IsGray = false;
            SaveResult(7);
        }

        private void ToGreenHandler(object obj)
        {
            IsGreen = false;
            SaveResult(6);
        }

        private void ToBrownHandler(object obj)
        {
            IsBrown = false;
            SaveResult(5);
        }

        private void ToYellowCommand(object obj)
        {
            IsYellow = false;
            SaveResult(4);
        }

        private void ToPurpleHandler(object obj)
        {
            IsPurple = false;
            SaveResult(3);
        }

        private void ToBlueHandler(object obj)
        {
            IsBlue = false;
            SaveResult(2);
        }

        private void ToRedHandler(object obj)
        {
            IsRed = false;
            SaveResult(1);
        }

        private void ToBlackHandler(object obj)
        {
            IsBlack = false;
            SaveResult(0);

        }

        public string CurrentInstruction
        {
            get => currentInstruction;
            set
            {
                if (currentInstruction != value)
                {
                    currentInstruction = value;
                    OnPropertyChanged(nameof(CurrentInstruction));
                }
            }
        }

        public string FirstResult
        {
            get => firstResult;
            set
            {
                if (firstResult != value)
                {
                    firstResult = value;
                    OnPropertyChanged(nameof(FirstResult));
                }
            }
        }

        public string SecondResult
        {
            get => secondResult;
            set
            {
                if (secondResult != value)
                {
                    secondResult = value;
                    OnPropertyChanged(nameof(SecondResult));
                }
            }
        }

        public string FirstColor
        {
            get => firstColor;
            set
            {
                if (firstColor != value)
                {
                    firstColor = value;
                    OnPropertyChanged(nameof(FirstColor));
                }
            }
        }

        public string SecondColor
        {
            get => secondColor;
            set
            {
                if (secondColor != value)
                {
                    secondColor = value;
                    OnPropertyChanged(nameof(SecondColor));
                }
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    OnPropertyChanged(nameof(FirstName));
                }
            }
        }

        public string SecondName
        {
            get => secondName;
            set
            {
                if (secondName != value)
                {
                    secondName = value;
                    OnPropertyChanged(nameof(SecondName));
                }
            }
        }

        public bool IsStart
        {
            get => isStart;
            set
            {
                if (isStart != value)
                {
                    isStart = value;
                    OnPropertyChanged(nameof(IsStart));
                }
            }
        }
        public bool IsFinish
        {
            get => isFinish;
            set
            {
                if (isFinish != value)
                {
                    isFinish = value;
                    OnPropertyChanged(nameof(IsFinish));
                }
            }
        }

        public bool IsBlack
        {
            get => isBlack;
            set
            {
                if (isBlack != value)
                {
                    isBlack = value;
                    OnPropertyChanged(nameof(IsBlack));
                }
            }
        }

        public bool IsRed
        {
            get => isRed;
            set
            {
                if (isRed != value)
                {
                    isRed = value;
                    OnPropertyChanged(nameof(IsRed));
                }
            }
        }

        public bool IsBlue
        {
            get => isBlue;
            set
            {
                if (isBlue != value)
                {
                    isBlue = value;
                    OnPropertyChanged(nameof(IsBlue));
                }
            }
        }

        public bool IsPurple
        {
            get => isPurple;
            set
            {
                if (isPurple != value)
                {
                    isPurple = value;
                    OnPropertyChanged(nameof(IsPurple));
                }
            }
        }

        public bool IsYellow
        {
            get => isYellow;
            set
            {
                if (isYellow != value)
                {
                    isYellow = value;
                    OnPropertyChanged(nameof(IsYellow));
                }
            }
        }

        public bool IsBrown
        {
            get => isBrown;
            set
            {
                if (isBrown != value)
                {
                    isBrown = value;
                    OnPropertyChanged(nameof(IsBrown));
                }
            }
        }

        public bool IsGreen
        {
            get => isGreen;
            set
            {
                if (isGreen != value)
                {
                    isGreen = value;
                    OnPropertyChanged(nameof(IsGreen));
                }
            }
        }

        public bool IsGray
        {
            get => isGray;
            set
            {
                if (isGray != value)
                {
                    isGray = value;
                    OnPropertyChanged(nameof(IsGray));
                }
            }
        }
    }
}
