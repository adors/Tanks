using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Game
    {
        public delegate void Over();
        public event Over onScore;
        public event Over onOver;
        List<Monolith> monoliths = new List<Monolith>();
        List<Apple> apples = new List<Apple>();
        List<Tree> trees = new List<Tree>();
        List<Water> waters = new List<Water>();
        List<Tank> tanks = new List<Tank>();
        List<Bullet> bullets = new List<Bullet>();
        int score;

        List<StaticObject> Objects = new List<StaticObject>();
        Kolobok kolobok;
        private Random rn; 
        int[,] mapArray = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1},
                {1, 1, 1, 0, 1, 1, 0, 0, 1, 0, 1, 1},
                {1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 1, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
                {1, 0, 1, 0, 1, 0, 1, 0, 1, 0, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
            };

        public void NewGame(int countTank, int countApple)
        {
            score = 0;
            rn = new Random();
            int xKor = 50;
            for (int i = 0; i < countTank; i++)
            {
                tanks.Add(new Tank(xKor, 50));
                Objects.Add(tanks.Last<Tank>());
                xKor += 100;
            }
            for (int i = 0; i < countApple; i++)
            {
                apples.Add(new Apple());
                Apple app = apples.Last();
                app.X = rn.Next(1, 12) * 50;
                app.Y = rn.Next(1, 12) * 50;
                while (mapArray[app.Y/50, app.X/50] == 1)
                {
                    app.X = rn.Next(1, 12) * 50;
                    app.Y = rn.Next(1, 12) * 50;
                }
            }
            kolobok = new Kolobok(50, 400);
            Objects.Add(kolobok);
            int nx = 0;
            int ny = 0;
            for(int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (mapArray[i, j] == 1)
                    {
                        monoliths.Add(new Monolith(nx, ny));
                        Objects.Add(monoliths
                            .Last<Monolith>());
                    }
                    nx += 50;
                }
                nx = 0;
                ny += 50;
            }
        }

        
        public bool Collision(MovingObject obj)
        {

                foreach(var item in Objects)
                {

                if ((obj.X + 45 >= item.X) && (obj.X <= item.X + 45) && (obj.Y + 45 >= item.Y) && (obj.Y <= item.Y + 45) && (obj.X != item.X || obj.Y != item.Y))
                {

                    if (item is Kolobok && obj is Tank)
                    {
                        onOver();
                    }
                    return true;
                }
                }
            
            return false;
        }
        public bool Collis(Apple ap)
        {
            if ((kolobok.X + 45 >= ap.X) && (kolobok.X <= ap.X + 45) && (kolobok.Y + 45 >= ap.Y) && (kolobok.Y <= ap.Y + 45))
            {
                return true;
            }
            return false;
        }

        public bool CollisionBullet(MovingObject obj)
        {

            foreach (var item in Objects)
            {

                if ((obj.X + 45 >= item.X) && (obj.X <= item.X + 45) && (obj.Y + 45 >= item.Y) && (obj.Y <= item.Y + 45) && (obj.X != item.X || obj.Y != item.Y))
                {
                    
                    if (item is Tank)
                    {
                        bullets.Remove((Bullet)obj);
                        tanks.Remove((Tank)item);
                       
                        item.X = 500;
                        item.Y = 500;
                        while (Collision((MovingObject)item))
                        {
                            item.X -= 50;
                        } 
                        tanks.Add((Tank)item);
                        tanks.Last().TravelDirection = rn.Next(1, 5);
                        
                        return true;
                    }

                    if (item is Monolith)
                    {
                        bullets.Remove((Bullet)obj);
                        return true;
                    }
                    if (item is Kolobok)
                    {
                        GameOver();

                        return true;
                    }
                }
            }

            return false;
        }

        private void GameOver()
        {
            tanks.Clear();
            bullets.Clear();
            monoliths.Clear();
            apples.Clear();
            onOver();
        }

        public bool CollisionApple(Apple obj)
        {

            foreach (var item in monoliths)
            {

                if ((obj.X + 45 >= item.X) && (obj.X <= item.X + 45) && (obj.Y + 45 >= item.Y) && (obj.Y <= item.Y + 45) && (obj.X != item.X || obj.Y != item.Y))
                    return true;
            }

            return false;
        }

        public bool Collides (int x, int y, int dx, int dy, int x2, int y2, int dx2, int dy2)
        {
            return !(dx <= x2 || x > dx2 || dy <= y2 || y > dy2);
        }

        public bool BoxCollides(int x, int y, int x2, int y2)
        {
            return Collides(x,y,x + 50,y+50, x2,y2,x2+50,y2+50);
        }

        public void Shot()
        {
            int xx = 0;
            int yy = 0;
            switch (TravelKolobok)
            {
                case 1:
                    yy = kolobok.Y - 51;
                    xx = kolobok.X;
                    break;
                case 2:
                    yy = kolobok.Y + 51;
                    xx = kolobok.X;
                    break;
                case 3:
                    yy = kolobok.Y;
                    xx = kolobok.X - 51;
                    break;
                case 4:
                    yy = kolobok.Y;
                    xx = kolobok.X + 51;
                    break;
            }
            bullets.Add(new Bullet(xx, yy, TravelKolobok));
        }

        public void Shot(Tank tn)
        {
            int xx = 0;
            int yy = 0;
            switch (tn.TravelDirection)
            {
                case 1:
                    yy = tn.Y - 51;
                    xx = tn.X;
                    break;
                case 2:
                    yy = tn.Y + 51;
                    xx = tn.X;
                    break;
                case 3:
                    yy = tn.Y;
                    xx = tn.X - 51;
                    break;
                case 4:
                    yy = tn.Y;
                    xx = tn.X + 51;
                    break;
            }
            bullets.Add(new Bullet(xx, yy, tn.TravelDirection));
        }

        public void Update()
        {
            
            foreach (var item in tanks)
            {
                if ((item.Count + rn.Next(1, 200)) > 280)
                {
                    Shot(item);
                    item.Count = 0;
                }
                item.Move();
                if (Collision(item))
                {
                    item.Turn(rn.Next(1, 5));
                    item.X = item.OldX;
                    item.Y = item.OldY;
                }
            }
            kolobok.Move();
            
            if (Collision(kolobok))
            {
                kolobok.X = kolobok.OldX;
                kolobok.Y = kolobok.OldY;
            }

            foreach (var item in apples)
            {
                if (Collis(item))
                {
                    
                    score++;
                    onScore();
                    item.X = rn.Next(1, 12) * 50;
                    item.Y = rn.Next(1, 12) * 50;
                    while (mapArray[item.Y / 50, item.X / 50] == 1)
                    {
                        item.X = rn.Next(1, 12) * 50;
                        item.Y = rn.Next(1, 12) * 50;
                    }
                }
            }

            foreach (var item in bullets)
            {
                item.Move();
                if (CollisionBullet(item)) break;
            }

        }

        public List<Tank> Tanks 
        {
            get 
            {
                return tanks;
            }

        }

        public List<Apple> Apples
        {
            get
            {
                return apples;
            }

        }

        public List<Bullet> Bullets
        {
            get
            {
                return bullets;
            }
        }

        public List<Monolith> Monoliths
        {
            get
            {
                return monoliths;
            }

        }

        public Kolobok Kolobok
        {
            get
            {
                return kolobok;
            }
        }

        public int TravelKolobok
        {
            get
            {
                return kolobok.TravelDirection;
            }

            set
            {
                kolobok.TravelDirection = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
        }
    }
}
