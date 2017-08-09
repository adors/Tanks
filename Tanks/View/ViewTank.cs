using System;
using System.Collections.Generic;
using System.Text;
using MVC;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using Tanks.Properties;
namespace Tanks
{
    class ViewTank : ViewDynamicMapObject
    {
        public ViewTank(Panel map) : base(map)
        {
            picBox.Image = Resources.TankU;
        }

        protected override void ChangePicture()
        {
            switch (Model.DirectionNow)
            {
                case (int)Direction.Up:
                    {
                        picBox.Image = Resources.TankU;
                        break;
                    }
                case ((int)Direction.Down):
                    {
                        picBox.Image = Resources.TankD;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        picBox.Image = Resources.TankR;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        picBox.Image = Resources.TankL;
                        break;
                    }
                default:
                    break;
            }
        }

    }
}
