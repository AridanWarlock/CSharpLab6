using System.ComponentModel;

namespace CSharpLab6
{
    using System.Windows.Forms;
    public record RedButtonEventArgs(int buttonNumber);
    public partial class NuPogodi : UserControl
    {
        private List<List<TransPanel>> _eggPanels;

        private Timer _timer;

        private enum BasketState
        {
            None = -1,
            LeftUp = 0,
            LeftDown,
            RightUp,
            RightDown,
        }
        private BasketState _basketState = BasketState.None;
        private enum ChickState
        {
            None = -1,
            First,
            Second,
            Third,
        }
        private ChickState _leftChickState = ChickState.None;
        private ChickState _rightChickState = ChickState.None;
        private void ChangeBasketState(BasketState state)
        {
            _basketState = state;

            switch (_basketState)
            {
                case BasketState.None:
                    Волк_Л.Visible = false;
                    Волк_П.Visible = false;

                    Корзина_ЛВ.Visible = false;
                    Корзина_ЛН.Visible = false;
                    Корзина_ПВ.Visible = false;
                    Корзина_ПН.Visible = false;
                    break;

                case BasketState.LeftUp:
                    Волк_Л.Visible = true;
                    Волк_П.Visible = false;

                    Корзина_ЛВ.Visible = true;
                    Корзина_ЛН.Visible = false;
                    Корзина_ПВ.Visible = false;
                    Корзина_ПН.Visible = false;
                    break;

                case BasketState.LeftDown:
                    Волк_Л.Visible = true;
                    Волк_П.Visible = false;

                    Корзина_ЛВ.Visible = false;
                    Корзина_ЛН.Visible = true;
                    Корзина_ПВ.Visible = false;
                    Корзина_ПН.Visible = false;
                    break;
                case BasketState.RightUp:
                    Волк_Л.Visible = false;
                    Волк_П.Visible = true;

                    Корзина_ЛВ.Visible = false;
                    Корзина_ЛН.Visible = false;
                    Корзина_ПВ.Visible = true;
                    Корзина_ПН.Visible = false;
                    break;
                case BasketState.RightDown:
                    Волк_Л.Visible = false;
                    Волк_П.Visible = true;

                    Корзина_ЛВ.Visible = false;
                    Корзина_ЛН.Visible = false;
                    Корзина_ПВ.Visible = false;
                    Корзина_ПН.Visible = true;
                    break;
            }
        }
        private void ChangeChickState(ChickState chickState, bool isLeft)
        {
            if (isLeft)
            {
                _leftChickState = chickState;
                switch (chickState)
                {
                    case ChickState.None:
                        Цепленок_Л_0.Visible = false;
                        Цепленок_Л_1.Visible = false;
                        Цепленок_Л_2.Visible = false;
                        Цепленок_Л_3.Visible = false;
                        break;
                    case ChickState.First:
                        Цепленок_Л_0.Visible = false;
                        Цепленок_Л_1.Visible = true;
                        Цепленок_Л_2.Visible = false;
                        Цепленок_Л_3.Visible = false;
                        break;
                    case ChickState.Second:
                        Цепленок_Л_0.Visible = false;
                        Цепленок_Л_1.Visible = false;
                        Цепленок_Л_2.Visible = true;
                        Цепленок_Л_3.Visible = false;
                        break;
                    case ChickState.Third:
                        Цепленок_Л_0.Visible = false;
                        Цепленок_Л_1.Visible = false;
                        Цепленок_Л_2.Visible = false;
                        Цепленок_Л_3.Visible = true;
                        break;
                }
                return;
            }

            _rightChickState = chickState;
            switch (chickState)
            {
                case ChickState.None:
                    Цепленок_П_0.Visible = false;
                    Цепленок_П_1.Visible = false;
                    Цепленок_П_2.Visible = false;
                    Цепленок_П_3.Visible = false;
                    break;
                case ChickState.First:
                    Цепленок_П_0.Visible = false;
                    Цепленок_П_1.Visible = true;
                    Цепленок_П_2.Visible = false;
                    Цепленок_П_3.Visible = false;
                    break;
                case ChickState.Second:
                    Цепленок_П_0.Visible = false;
                    Цепленок_П_1.Visible = false;
                    Цепленок_П_2.Visible = true;
                    Цепленок_П_3.Visible = false;
                    break;
                case ChickState.Third:
                    Цепленок_П_0.Visible = false;
                    Цепленок_П_1.Visible = false;
                    Цепленок_П_2.Visible = false;
                    Цепленок_П_3.Visible = true;
                    break;
            }
        }
        public NuPogodi()
        {
            InitializeComponent();

            _eggPanels = [
                [Яйцо_ЛВ_0, Яйцо_ЛВ_1, Яйцо_ЛВ_2, Яйцо_ЛВ_3, Яйцо_ЛВ_4],
                [Яйцо_ЛН_0, Яйцо_ЛН_1, Яйцо_ЛН_2, Яйцо_ЛН_3, Яйцо_ЛН_4],
                [Яйцо_ПВ_0, Яйцо_ПВ_1, Яйцо_ПВ_2, Яйцо_ПВ_3, Яйцо_ПВ_4],
                [Яйцо_ПН_0, Яйцо_ПН_1, Яйцо_ПН_2, Яйцо_ПН_3, Яйцо_ПН_4]
            ];

            InitialCondition();

            _timer = new Timer()
            {
                Interval = 1000,
            };
            _timer.Tick += RefreshState!;
        }
        private void InitialCondition()
        {
            var time = TimeOnly.FromDateTime(DateTime.Now);
            ДПVisible = time.Hour < 12;

            Рука_зайца_ВVisible = true;
            Колокольчик_ВVisible = true;

            Штраф_1.Visible = false;
            Штраф_2.Visible = false;
            Штраф_3.Visible = false;

            Игра_АVisible = true;

            Разбитое_ЛVisible = false;
            Разбитое_ПVisible = false;

            Игра_А.Visible = false;
            Игра_Б.Visible = false;

            _eggPanels.ForEach(line => line.ForEach(egg => egg.Visible = false));

            ChangeBasketState(BasketState.None);

            ChangeChickState(ChickState.None, false);
            ChangeChickState(ChickState.None, true);

            Faults = 0;
            WinnerPoints = 0;
            winnerPointsTextBox.Text = WinnerPoints.ToString();
        }
        public int WinnerPoints { get; private set; } = 0;
        public int Faults { get; private set; } = 0;
        public delegate void RedButtonClick(object sender, RedButtonEventArgs e);
        public event RedButtonClick? OnRedButtonClicked;
        private void RefreshState(object sender, EventArgs e)
        {
            if (!_timer.Enabled)
                return;

            if (Faults == 3)
            {
                _timer.Enabled = false;
                MessageBox.Show("Вы проиграли!", $"Набранно {WinnerPoints} очков");
                return;
            }

            UpdateEggsState();
            UpdateChickState();

            Рука_зайца_ВVisible = !Рука_зайца_ВVisible;
            Колокольчик_ВVisible = !Колокольчик_ВVisible;
        }
        private void UpdateChickState()
        {
            switch (_leftChickState)
            {
                case ChickState.None:
                    break;
                case ChickState.First:
                    ChangeChickState(ChickState.Second, true);
                    break;
                case ChickState.Second:
                    ChangeChickState(ChickState.Third, true);
                    break;
                case ChickState.Third:
                    ChangeChickState(ChickState.None, true);
                    break;
            }

            switch (_rightChickState)
            {
                case ChickState.None:
                    break;
                case ChickState.First:
                    ChangeChickState(ChickState.Second, false);
                    break;
                case ChickState.Second:
                    ChangeChickState(ChickState.Third, false);
                    break;
                case ChickState.Third:
                    ChangeChickState(ChickState.None, false);
                    break;
            }
        }
        private void UpdateEggsState()
        {
            var lineNumber = 0;
            foreach (var line in _eggPanels)
            {
                for (var i = line.Count - 1; i >= 0; i--)
                {
                    if (!line[i].Visible)
                    {
                        continue;
                    }

                    if (i == line.Count - 1)
                    {
                        line[i].Visible = false;
                        DropEgg(lineNumber);

                        continue;
                    }

                    line[i].Visible = false;
                    line[i + 1].Visible = true;
                }
                lineNumber++;
            }

            var newLine = new Random().Next(_eggPanels.Count * 2);
            if (newLine > _eggPanels.Count - 1)
                return;

            _eggPanels[newLine][0].Visible = true;


        }
        private void DropEgg(int lineNumber)
        {
            if (lineNumber == (int)_basketState)
            {
                WinnerPoints++;
                winnerPointsTextBox.Text = WinnerPoints.ToString();
                return;
            }

            if (lineNumber <= _eggPanels.Count / 2)
            {
                if (!Разбитое_ЛVisible)
                    ChangeChickState(ChickState.First, true);
                Разбитое_ЛVisible = true;
            }
            else
            {
                if (!Разбитое_ПVisible)
                    ChangeChickState(ChickState.First, false);

                Разбитое_ПVisible = true;
            }
            Faults++;
            switch (Faults)
            {
                case 1:
                    Штраф_1.Visible = true;
                    break;
                case 2:
                    Штраф_2.Visible = true;
                    break;
                case 3:
                    Штраф_3.Visible = true;
                    break;
            }
        }
        private void redButton0_Click(object sender, EventArgs e)
        {
            ChangeBasketState(BasketState.LeftUp);
            OnRedButtonClicked?.Invoke(sender, new RedButtonEventArgs((int)_basketState));
        }
        private void redButton1_Click(object sender, EventArgs e)
        {
            ChangeBasketState(BasketState.LeftDown);
            OnRedButtonClicked?.Invoke(sender, new RedButtonEventArgs((int)_basketState));
        }
        private void redButton2_Click(object sender, EventArgs e)
        {
            ChangeBasketState(BasketState.RightUp);
            OnRedButtonClicked?.Invoke(sender, new RedButtonEventArgs((int)_basketState));
        }
        private void redButton3_Click(object sender, EventArgs e)
        {
            ChangeBasketState(BasketState.RightDown);
            OnRedButtonClicked?.Invoke(sender, new RedButtonEventArgs((int)_basketState));
        }
        private void game1Button_Click(object sender, EventArgs e)
        {
            InitialCondition();
            Игра_АVisible = true;
            _timer.Start();
        }
        private void gane2Button_Click(object sender, EventArgs e)
        {
            InitialCondition();
            Игра_БVisible = true;
            _timer.Start();
        }
        public int BasketPosition { get => (int)_basketState; }
        public int RunningChickLeft { get => (int)_leftChickState; }
        public int RunningChickRight { get => (int)_rightChickState; }
        public IEnumerable<IEnumerable<bool>> Eggs
        {
            get => _eggPanels.Select(eggs => eggs.Select(egg => egg.Visible));
        }
        public bool ЧасыVisible
        {
            get => Часы.Visible;
            private set => Часы.Visible = value;
        }
        public bool ДПVisible
        {
            get => ДП.Visible;
            private set
            {
                ДП.Visible = value;
                ПП.Visible = !value;
            }
        }
        public bool ППVisible
        {
            get => ПП.Visible;
            private set
            {
                ПП.Visible = value;
                ДП.Visible = !value;
            }
        }
        public bool ЗаяцVisible
        {
            get => Заяц.Visible;
            private set => Заяц.Visible = value;
        }
        public bool Рука_зайца_ВVisible
        {
            get => Рука_зайца_В.Visible;
            private set
            {
                Рука_зайца_В.Visible = value;
                Рука_зайца_Н.Visible = !value;
            }
        }
        public bool Рука_зайца_НVisible
        {
            get => Рука_зайца_Н.Visible;
            private set
            {
                Рука_зайца_Н.Visible = value;
                Рука_зайца_В.Visible = !value;
            }
        }
        public bool Колокольчик_ВVisible
        {
            get => Колокольчик_В.Visible;
            private set
            {
                Колокольчик_В.Visible = value;
                Колокольчик_Н.Visible = !value;
            }
        }
        public bool Колокольчик_НVisible
        {
            get => Колокольчик_Н.Visible;
            private set
            {
                Колокольчик_Н.Visible = value;
                Колокольчик_В.Visible = !value;
            }
        }
        public bool Игра_АVisible
        {
            get => Игра_А.Visible;
            private set
            {
                Игра_А.Visible = value;
                Игра_Б.Visible = !value;
            }
        }
        public bool Игра_БVisible
        {
            get => Игра_Б.Visible;
            private set
            {
                Игра_Б.Visible = value;
                Игра_А.Visible = !value;
            }
        }
        public bool Разбитое_ЛVisible
        {
            get => Разбитое_Л.Visible;
            private set
            {
                Разбитое_Л.Visible = value;
            }
        }
        public bool Разбитое_ПVisible
        {
            get => Разбитое_П.Visible;
            private set
            {
                Разбитое_П.Visible = value;
            }
        }
    }
}
