using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Model;

namespace View
{
    public class KolobokView
    {
        private Kolobok kolobokModel;
        private Image _kolobokImg = Properties.Resources.Kolobok;

        public KolobokView(Kolobok kolobok)
        {
            kolobokModel = kolobok;
        }

        public Image GetImage
        {
            get 
            {
                return _kolobokImg;
            }
        }

        public int X
        {
            get
            {
                return kolobokModel.X;
            }
        }

        public int Y
        {
            get
            {
                return kolobokModel.Y;
            }
        }

    }
}
