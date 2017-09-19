using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Model;

namespace View
{
    public class ViewMap
    {

       
        private PictureBox _pctBox;
        private Graphics _graphic;
        private Bitmap _bitmap;
        private KolobokView kolobokView;
        private List<TankView> tanksView = new List<TankView>();
        
        private Game game;

        public ViewMap(PictureBox pctBox, Game game)
        {
            _pctBox = pctBox;
            _bitmap = new Bitmap(pctBox.Width, pctBox.Height);
            _graphic = Graphics.FromImage(_bitmap);
            this.game = game;
            foreach (Tank item in game.Tanks)
            {
                tanksView.Add(new TankView(item));
            }
            kolobokView = new KolobokView(game.Kolobok);
            UpdateMap();
            
            
        }

        public void UpdateMap()
        {
            ClearMap();
            _graphic.DrawImage(kolobokView.GetImage, kolobokView.X, kolobokView.Y);
            foreach (Monolith item in game.Monoliths)
            {
                _graphic.DrawImage(Properties.Resources.Monolith, item.X, item.Y);
            }

            foreach (Bullet item in game.Bullets)
            {
                _graphic.DrawImage(Properties.Resources.Bullet, item.X, item.Y);
            }

            foreach (Apple item in game.Apples)
            {
                _graphic.DrawImage(Properties.Resources.Apple, item.X, item.Y);
            }

            foreach (TankView item in tanksView)
            {
                _graphic.DrawImage(item.GetImage(), item.X, item.Y);
            }
            _pctBox.Image = _bitmap;
        }

        private void ClearMap()
        {
            _graphic.Clear(_pctBox.BackColor);
        }
    }
}
