using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tanks.Properties;

namespace Tanks.View
{
    class ViewPackMan : ViewDynamicMapObject
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="map">Поле игры</param>
        public ViewPackMan(Panel map) : base(map)
        {
            picBox.Image = Resources.PackManD;
        }
        /// <summary>
        /// Смена картинки при смене направления движения
        /// </summary>
        protected override void ChangePicture()
        {
            switch (Model.DirectionNow)
            {
                case (int)Direction.Up:
                    {
                        picBox.Image = Resources.PackManU;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        picBox.Image = Resources.PackManD;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        picBox.Image = Resources.PackManR;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        picBox.Image = Resources.PackManL;
                        break;
                    }
                default:
                    break;
            }
        }

    }
}
