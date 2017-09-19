using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Drawing;

namespace View
{
    public class TankView
    {
        private Tank _tankModel;
        private Image _tankImgTop = Properties.Resources.TankTop;
        private Image _tankImgBot = Properties.Resources.TankBot;
        private Image _tankImgLeft = Properties.Resources.TankLeft;
        private Image _tankImgRight = Properties.Resources.TankRight;

        public TankView(Tank tank)
        {
            _tankModel = tank;
        }

        public Image GetImage()
        {
            switch (_tankModel.TravelDirection)
            {
                case 1:
                    return _tankImgTop;
                case 2:
                    return _tankImgBot;
                case 3:
                    return _tankImgLeft;
                case 4:
                    return _tankImgRight;
                default:
                    return _tankImgBot;
            }
        }

        public int X
        {
            get
            {
                return _tankModel.X;
            }
        }

        public int Y
        {
            get
            {
                return _tankModel.Y;
            }
        }
    }
}
