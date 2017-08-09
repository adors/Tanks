using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tanks.Model;

namespace Tanks
{
    public class PackMan : DynamicMapObject
    {
        /// <summary>
        /// Количество жизней
        /// </summary>
        private int life = 3;
        /// <summary>
        /// Метод запуска
        /// </summary>
        public override void Run()
        {
            while (true)
            {
                OnCheck();
                Move();
            }
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        public PackMan() : base()
        {
            delta = 2;
        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="position">Координаты</param>
        public PackMan(Point position) : base(position)
        {
            delta = 2;
        }
        /// <summary>
        /// Смерть Пакмена.
        /// </summary>
        public void Die()
        {
            //    viewGame.Model.Dispose();
            OnReplaceNeeded();
        }
        /// <summary>
        /// Обработчик события смена координат
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void OnCheckPosition(object sender, EventArgs e)
        {
            PositionChangedEventArgs positionArgs = e as PositionChangedEventArgs;
            if (positionArgs == null)
                return;
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if (sender is Tank)
                    Die();
            }
        }

    }
}
