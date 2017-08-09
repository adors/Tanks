using System;
using System.Collections.Generic;
using System.Text;
using MVC;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Tanks.Properties;
namespace Tanks
{
    class ViewKolobok : ViewDynamicMapObject
    {
        public ViewKolobok(Panel map) : base(map)
        {
            picBox.Image = Resources.PackManD;
        }

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
