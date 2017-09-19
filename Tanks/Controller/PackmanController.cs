using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;

namespace Controller
{
    public class PackmanController
    {
        public delegate void MethodUpdate();
        public event MethodUpdate onTimer;
        private Game game;
        private Timer timer;
        public PackmanController(int interval, int countTanks, int countApple)
        {
            timer = new Timer();
            timer.Enabled = true;
            timer.Interval = interval;
            timer.Tick += Update;
            game = new Game();
            game.NewGame(countTanks, countApple);
        }

        public void Update(object sender, EventArgs e)
        {
            game.Update();
            onTimer();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Shot()
        {
            game.Shot();
        }

        public Game Game
        {
            get
            {
                return game;
            }
        }

        public int TravelPackman
        {
            get
            {
                return game.TravelKolobok;
            }

            set
            {
                game.TravelKolobok = value;
            }
        }
    }
}
