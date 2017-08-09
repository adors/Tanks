using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
namespace Tanks
{
    class KolobokController
    {
        private DateTime lastShotTime;

        public DateTime LastShotTime
        {
            get { return lastShotTime; }
            set { lastShotTime = value; }
        }

        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Up:
                    {
                        ((Game)sender).Kolobok.IdentifyDirection((int)Direction.Up);
                        break;
                    }
                case Keys.Down:
                    {
                        ((Game)sender).Kolobok.IdentifyDirection((int)Direction.Down);
                        break;
                    }
                case Keys.Left:
                    {
                        ((Game)sender).Kolobok.IdentifyDirection((int)Direction.Left);
                        break;
                    }
                case Keys.Right:
                    {
                        ((Game)sender).Kolobok.IdentifyDirection((int)Direction.Right);
                        break;
                    }
                case Keys.F:
                    {
                        if ((DateTime.Now.Subtract(lastShotTime)).TotalMilliseconds > 350)
                        {
                            lastShotTime = DateTime.Now;
                            ((Game)sender).CreateKolobokRocket();
                        }
                        break;
                    }
                default:
                    break;
            }
        }
    }
}
