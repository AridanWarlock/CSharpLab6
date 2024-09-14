using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpLab6
{
    public partial class NuPogodi : UserControl
    {
        public NuPogodi()
        {
            InitializeComponent();
           
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
                Разбитое_П.Visible = !value;
            }
        }
        public bool Разбитое_ПVisible
        {
            get => Разбитое_П.Visible;
            private set
            {
                Разбитое_П.Visible = value;
                Разбитое_Л.Visible = !value;
            }
        }
    }
}
