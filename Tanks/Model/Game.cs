using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading;
using System.ComponentModel;
using Tanks.Model;
using System.Windows.Forms;
using System.Linq;

namespace Tanks
{
    class Game
    {
        Random rand = new Random();
        List<Tank> tanks = new List<Tank>();
        List<Wall> walls = new List<Wall>();
        List<Apple> apples = new List<Apple>();
        List<Rocket> rockets = new List<Rocket>();
        Kolobok kolobok;
        KolobokController controller = new KolobokController();
        private System.Windows.Forms.Timer timer;

        private int countTank;
        private int countApple;
        int MAXX;
        int MAXY;
        int length;

        private static int score = 0;

        public List<Apple> Apples
        {
            get { return apples; }
        }

        public List<Wall> Walls
        {
            get { return walls; }
        }

        public Kolobok Kolobok
        {
            get { return kolobok; }
        }

        public List<Tank> Tanks
        {
            get { return tanks; }
        }

        public List<Rocket> Rockets
        {
            get { return rockets; }
        }

        public int CountTank
        {
            get { return countTank; }
        }
        public int CountApple
        {
            get { return countApple; }
        }

        private event KeyEventHandler keyPress;
        public virtual void OnKeyPress(Keys key)
        {
            if (keyPress != null)
                keyPress(this, new KeyEventArgs(key));
        }

        public event EventHandler RocketCreatedE;
        protected virtual void OnRocketCreatedE()
        {
            if (RocketCreatedE != null)
                RocketCreatedE(this, new EventArgs());
        }

        public event EventHandler GameEndE;
        protected virtual void OnGameEndE()
        {
            if (GameEndE != null)
                GameEndE(this, new EventArgs());
        }

        public event EventHandler GameOverE;
        protected virtual void OnGameOverE()
        {
            if (GameOverE != null)
                GameOverE(this, new EventArgs());
        }

        public event EventHandler ScoreChangedE;
        protected virtual void OnScoreChangedE()
        {
            if (ScoreChangedE != null)
                ScoreChangedE(this, new EventArgs());
        }

        public void SubscribeKeyPress()
        {
            this.keyPress += new KeyEventHandler(controller.OnKeyPress);
            controller.OnKeyPress(this, new KeyEventArgs(Keys.Right));
        }

        public int Score
        {
            get { return score; }
            set
            {
                score = value;
                OnScoreChangedE();
            }
        }

        public void CreateKolobokRocket()
        {
            int dir = kolobok.DirectionNow;
            Point pos = kolobok.Position;
            switch (dir)
            {
                case 3:
                    {
                        pos.Y += kolobok.Height;
                        pos.X += kolobok.Width / 2;
                        break;
                    }
                case 1:
                    {
                        pos.Y += kolobok.Height / 2;
                        break;
                    }
                case 0:
                    {
                        pos.X += kolobok.Width;
                        pos.Y += kolobok.Height / 2;
                        break;
                    }
                case 2:
                    {
                        pos.X += kolobok.Width / 2;
                        break;
                    }
                default:
                    break;
            }

            rockets.Add(new Rocket(pos, dir));
            OnRocketCreatedE();
            SubscribeOnkolobokRocket();
        }

        public void CreateTankRocket(Tank tank)
        {
            int dir = tank.DirectionNow;
            Point pos = tank.Position;
            switch (dir)
            {
                case 3:
                    {
                        pos.Y += tank.Height;
                        pos.X += tank.Width / 2;
                        break;
                    }
                case 1:
                    {
                        pos.Y += tank.Height / 2;
                        break;
                    }
                case 0:
                    {
                        pos.X += tank.Width;
                        pos.Y += tank.Height / 2;
                        break;
                    }
                case 2:
                    {
                        pos.X += tank.Width / 2;
                        break;
                    }
                default:
                    break;
            }
            rockets.Add(new Rocket(pos, dir));
            OnRocketCreatedE();
            SubscribeOnTankRocket();
        }

        private void SubscribeOnTankRocket()
        {
            rockets.Last().CheckPosition += new EventHandler(kolobok.OnCheckPosition);

            for (int i = 0; i < walls.Count; i++)
            {
                rockets.Last().CheckPosition += new EventHandler(walls[i].OnCheckPosition);
            }
            rockets.Last().Died += new EventHandler(OnDied);
        }

        private void SubscribeOnkolobokRocket()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                rockets.Last().CheckPosition += new EventHandler(tanks[i].OnCheckPosition);
            }

            for (int i = 0; i < walls.Count; i++)
            {
                rockets.Last().CheckPosition += new EventHandler(walls[i].OnCheckPosition);
            }

            rockets.Last().Died += new EventHandler(OnDied);
        }

        private void OnDied(object sender, EventArgs e)
        {
            if (sender is Rocket)
            {
                rockets.Remove((Rocket)sender);
            }

            if (sender is Tank)
            {
                for (int i = 0; i < tanks.Count; i++)
                {
                    if (tanks[i] != (Tank)sender)
                    {
                        tanks[i].CheckPosition -= new EventHandler(((Tank)sender).OnCheckPosition);
                    }
                }

                for (int i = 0; i < rockets.Count; i++)
                {
                    rockets[i].CheckPosition -= new EventHandler(((Tank)sender).OnCheckPosition);
                }

                kolobok.CheckPosition -= new EventHandler(((Tank)sender).OnCheckPosition);

                tanks.Remove((Tank)sender);
            }

            if (sender is Wall)
            {
                for (int i = 0; i < tanks.Count; i++)
                {
                    tanks[i].CheckPosition -= new EventHandler(((Wall)sender).OnCheckPosition);
                }

                for (int i = 0; i < rockets.Count; i++)
                {
                    rockets[i].CheckPosition -= new EventHandler(((Wall)sender).OnCheckPosition);
                }

                kolobok.CheckPosition -= new EventHandler(((Wall)sender).OnCheckPosition);
                walls.Remove((Wall)sender);
            }

        }

        public void UnsubscribeKeyPress()
        {
            this.keyPress -= new KeyEventHandler(controller.OnKeyPress);
        }

        public Game(System.Windows.Forms.Timer timer, int speed, int tank, int apple)
        {
            countApple = apple;
            countTank = tank;
            MAXX = 500;
            MAXY = 500;
            this.timer = new System.Windows.Forms.Timer { Interval = 20 - speed };
            this.timer.Tick += OnTick;

            PlaceWalls();


            for (int i = 0; i < countTank; i++)
            {
                Rectangle rect = new Rectangle();
                do
                {
                    rect = new Rectangle(rand.Next(0, MAXX), rand.Next(0, MAXY), (new Tank()).Width, (new Tank()).Height);
                } while (Collides(rect));
                System.Threading.Thread.Sleep(10);
                tanks.Add(new Tank(rect.Location, i));
            }


            for (int i = 0; i < countApple; i++)
            {
                Rectangle rect = new Rectangle();
                do
                {
                    rect = new Rectangle(rand.Next(0, MAXX), rand.Next(0, MAXY), (new Apple()).Width, (new Apple()).Height);
                } while (Collides(rect));

                apples.Add(new Apple(rect.Location, i));
            }
            Rectangle rect2 = new Rectangle();
            do
            {
                rect2 = new Rectangle(rand.Next(0, MAXX), rand.Next(0, MAXY), (new Kolobok()).Width, (new Kolobok()).Height);
            } while (Collides(rect2));


            kolobok = new Kolobok(rect2.Location);

            SubscribePos();
            kolobok.Died += new EventHandler(OnDied);
        }

        private void OnTick(object sender, EventArgs e)
        {

            if (!kolobok.Alive)
            {
                GameOver();
            }
            if (tanks.Count == 0 && kolobok.Alive)
                GameEnd();
            for (int i = 0; i < rockets.Count; i++)
            {
                rockets[i].Run();
            }
            kolobok.Run();
            for (int i = 0; i < tanks.Count; i++)
            {
                tanks[i].Run();
                if (rand.Next(0, 220) == 1)
                {
                    CreateTankRocket(tanks[i]);
                }
            }
        }

        private void GameEnd()
        {
            timer.Stop();
            UnSubscribePos();
            kolobok.Die();
            int tempCount = tanks.Count;
            for (int i = walls.Count - 1; i >= 0; i--)
            {
                walls[i].Die();
            }
            for (int i = apples.Count - 1; i >= 0; i--)
            {
                apples[i].Die();
            }
            for (int i = rockets.Count - 1; i >= 0; i--)
            {
                rockets[i].Die();
            }
            OnGameEndE();
        }

        public Game()
        {
        }

        public void GameOver()
        {
            timer.Stop();
            UnSubscribePos();
            kolobok.Die();
            int tempCount = tanks.Count;
            for (int i = tempCount - 1; i >= 0; i--)
            {
                tanks[i].Die();
            }
            for (int i = walls.Count - 1; i >= 0; i--)
            {
                walls[i].Die();
            }
            for (int i = 0; i < apples.Count; i++)
            {
                apples[i].Die();
            }
            for (int i = rockets.Count - 1; i >= 0; i--)
            {
                rockets[i].Die();
            }
            apples.Clear();
            OnGameOverE();
        }

        public void Start()
        {
            timer.Start();
        }

        private void PlaceWalls()
        {
            for (int i = 0; i < MainGameForm.countWall; i++)
            {
                Rectangle rect = new Rectangle();
                walls.Add(new Wall(rect.Location));
            }

            int cur = 0;
            for (int i = 0; i < MainGameForm.map.Length; i++)
            {
                for (int j = 0; j < MainGameForm.map[0].Length; j++)
                {
                    if (MainGameForm.map[i][j] == '*')
                    {
                        walls[cur].Position = new Point(i * walls[cur].Width, j * walls[cur].Height);
                        cur++;
                    }
                }
            }
        }

        private bool Collides(Rectangle rect)
        {
            if (rect.Left < 0 || rect.Right >= MAXX || rect.Top < 0 || rect.Bottom >= MAXY)
                return true;
            for (int i = 0; i < tanks.Count; i++)
            {
                if (tanks[i].CollidesWith(rect)) return true;
            }
            for (int i = 0; i < walls.Count; i++)
            {
                if (walls[i].CollidesWith(rect)) return true;
            }
            for (int i = 0; i < apples.Count; i++)
            {
                if (apples[i].CollidesWith(rect)) return true;
            }
            if (kolobok != null && kolobok.CollidesWith(rect)) return true;

            return false;
        }

        public void SubscribePos()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    if (i != j)
                    {
                        tanks[i].CheckPosition += new EventHandler(tanks[j].OnCheckPosition);
                    }
                }
                tanks[i].Died += new EventHandler(OnDied);
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < walls.Count; j++)
                {
                    tanks[i].CheckPosition += new EventHandler(walls[j].OnCheckPosition);
                }
            }
            for (int j = 0; j < walls.Count; j++)
            {
                kolobok.CheckPosition += new EventHandler(walls[j].OnCheckPosition);
                walls[j].Died += new EventHandler(OnDied);
            }
            for (int j = 0; j < tanks.Count; j++)
            {
                kolobok.CheckPosition += new EventHandler(tanks[j].OnCheckPosition);
            }
            for (int j = 0; j < tanks.Count; j++)
            {
                kolobok.CheckPosition += new EventHandler(tanks[j].OnCheckPosition);
            }
            for (int j = 0; j < apples.Count; j++)
            {
                kolobok.CheckPosition += new EventHandler(apples[j].OnCheckPosition);
            }

            kolobok.ReplaceNeeded += new EventHandler(kolobok_ReplaceNeeded);
            for (int j = 0; j < apples.Count; j++)
            {
                apples[j].ReplaceNeeded += new EventHandler(apple_ReplaceNeeded); 
            }

        }

        void apple_ReplaceNeeded(object sender, EventArgs e)
        {
            Rectangle rect2 = new Rectangle();
            do
            {
                rect2 = new Rectangle(rand.Next(0, MAXX - (sender as MapObject).Width - 2), rand.Next(MAXY - (sender as MapObject).Height - 2), (new Apple()).Width, (new Apple()).Height);
            } while (Collides(rect2));

            (sender as Apple).Position = rect2.Location;
            Score++;
        }

        void kolobok_ReplaceNeeded(object sender, EventArgs e)
        {
            Rectangle rect2 = new Rectangle();
            do
            {
                rect2 = new Rectangle(rand.Next(0, MAXX - (sender as MapObject).Width - 2), rand.Next(MAXY - (sender as MapObject).Height - 2), (new Kolobok()).Width, (new Kolobok()).Height);
            } while (Collides(rect2));

            kolobok.Position = rect2.Location;
        }

        private void UnSubscribePos()
        {
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < tanks.Count; j++)
                {
                    if (i != j)
                    {
                        tanks[i].CheckPosition -= new EventHandler(tanks[i].OnCheckPosition);
                    }
                }
            }
            for (int i = 0; i < tanks.Count; i++)
            {
                for (int j = 0; j < walls.Count; j++)
                {
                    tanks[i].CheckPosition -= new EventHandler(walls[j].OnCheckPosition);
                }
            }
            for (int j = 0; j < walls.Count; j++)
            {
                kolobok.CheckPosition -= new EventHandler(walls[j].OnCheckPosition);
            }
            for (int j = 0; j < tanks.Count; j++)
            {
                kolobok.CheckPosition -= new EventHandler(tanks[j].OnCheckPosition);
            }
            for (int j = 0; j < apples.Count; j++)
            {
                kolobok.CheckPosition -= new EventHandler(apples[j].OnCheckPosition);
            }

            kolobok.ReplaceNeeded -= new EventHandler(kolobok_ReplaceNeeded);
            for (int j = 0; j < apples.Count; j++)
            {
                apples[j].ReplaceNeeded -= new EventHandler(apple_ReplaceNeeded);
            }
        }
    }
}
