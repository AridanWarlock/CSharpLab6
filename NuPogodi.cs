using System.ComponentModel;

namespace CSharpLab6
{
    public partial class NuPogodi : UserControl
    {
        private List<List<TransPanel>> _eggPanels;

        private enum BasketState
        {
            None = -1,
            LeftUp,
            LeftDown,
            RightDown,
            RightUp,
        }
        private BasketState _state = BasketState.None;
        private void ChangeBasketState(BasketState state)
        {
            _state = state;

            switch (_state)
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

        public NuPogodi()
        {
            InitializeComponent();

            var time = TimeOnly.FromDateTime(DateTime.Now);
            ДПVisible = time.Hour < 12;

            Рука_зайца_ВVisible = true;
            Колокольчик_ВVisible = true;

            Штраф_1.Visible = false;
            Штраф_2.Visible = false;
            Штраф_3.Visible = false;

            Цепленок_Л_0.Visible = false;
            Цепленок_Л_1.Visible = false;
            Цепленок_Л_2.Visible = false;
            Цепленок_Л_3.Visible = false;

            Цепленок_П_0 .Visible = false;
            Цепленок_П_1 .Visible = false;
            Цепленок_П_2 .Visible = false;
            Цепленок_П_3 .Visible = false;

            Игра_АVisible = true;

            Разбитое_ЛVisible = false;
            Разбитое_ПVisible = false;

            _eggPanels = [
                [Яйцо_ЛВ_0, Яйцо_ЛВ_1, Яйцо_ЛВ_2, Яйцо_ЛВ_3, Яйцо_ЛВ_4],
                [Яйцо_ЛН_0, Яйцо_ЛН_1, Яйцо_ЛН_2, Яйцо_ЛН_3, Яйцо_ЛН_4],
                [Яйцо_ПВ_0, Яйцо_ПВ_1, Яйцо_ПВ_2, Яйцо_ПВ_3, Яйцо_ПВ_4],
                [Яйцо_ПН_0, Яйцо_ПН_1, Яйцо_ПН_2, Яйцо_ПН_3, Яйцо_ПН_4]
            ];

            _eggPanels.ForEach(line => line.ForEach(egg => egg.Visible = false));

            ChangeBasketState(BasketState.RightUp);

            RefreshState();
        }
        private void RefreshState()
        {
            
        }

        public int Faults { get; private set; } = 0;
        public int BasketPosition { get => (int)_state; }
        public int RunningChickLeft { get; private set; } = -1;
        public int RunningChickRight { get; private set; } = -1;
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
