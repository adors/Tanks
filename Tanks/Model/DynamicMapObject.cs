using System;
using System.Collections.Generic;
using System.Text;
using MVC;
using Tanks.MVC;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Tanks.Properties;
using System.Threading;
using Tanks.Model;

namespace Tanks
{
    public class DynamicMapObject : MapObject
    {
        int dy;
        int dx;
        bool flag = false;
        protected int delta;
        private int directionNow;

        public event EventHandler CheckPosition;

        public int DirectionNow
        {
            get { return directionNow; }
            set { directionNow = value; }
        }

        public DynamicMapObject() : base()
        {
        }

        public DynamicMapObject(Point position) : base(position)
        {
            delta = 1;
            dy = 0;
            dx = delta;
            Turn();
        }

        virtual public void Move()
        {
            if (position.X + dx >= 0 && position.X + this.Width + dx < MapSize.X)
            {
                position.X += dx;
            }
            else
            {
                Deviate();
            }

            if (position.Y + dy >= 0 && position.Y + this.Height + dy < MapSize.Y)
            {
                position.Y += dy;
            }
            else
            {
                Deviate();
            }

            flag = true;

            OnPositionChanged();

        }

        public void Stop()
        {
            dx = 0;
            dy = 0;
        }

        public void Deviate()
        {
            if (flag == true)
            {
                dx = -dx;
                dy = -dy;
                switch (directionNow)
                {
                    case (int)Direction.Left:
                        {
                            directionNow = (int)Direction.Right;
                            break;
                        }
                    case (int)Direction.Right:
                        {
                            directionNow = (int)Direction.Left;
                            break;
                        }
                    case (int)Direction.Up:
                        {
                            directionNow = (int)Direction.Down;
                            break;
                        }
                    case (int)Direction.Down:
                        {
                            directionNow = (int)Direction.Up;
                            break;
                        }
                }
                flag = false;
            }
        }

        public void Turn()
        {
            IdentifyDirection(rand.Next(0, 4));
        }

        public void IdentifyDirection(int direction)
        {
            switch (direction)
            {
                case (int)Direction.Down:
                    {
                        dy = delta;
                        dx = 0;
                        directionNow = (int)Direction.Down;
                        break;
                    }
                case (int)Direction.Left:
                    {
                        dy = 0;
                        dx = -delta;
                        directionNow = (int)Direction.Left;
                        break;
                    }
                case (int)Direction.Right:
                    {
                        dy = 0;
                        dx = delta;
                        directionNow = (int)Direction.Right;
                        break;
                    }
                case (int)Direction.Up:
                    {
                        dy = -delta;
                        dx = 0;
                        directionNow = (int)Direction.Up;
                        break;
                    }
                default:
                    break;
            }
        }

        public virtual void Run()
        {
            if (rand.Next(0, 100) == 1)
            {
                Turn();
            }

            OnCheck();
            Move();
        }


        protected virtual void OnCheck()
        {
            if (CheckPosition != null)
                CheckPosition(this, new PositionChangedEventArgs(new Rectangle(this.position.X + dx, this.position.Y + dy, this.Width, this.Height)));
        }
        public override void OnCheckPosition(object sender, EventArgs e)
        {
            PositionChangedEventArgs positionArgs = e as PositionChangedEventArgs;
            if (positionArgs == null)
                return;
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if (sender is Tank)
                {
                    this.Deviate();
                    ((DynamicMapObject)sender).Deviate();
                }

                if (sender is Kolobok)
                {
                    (sender as Kolobok).Life--;

                    if ((sender as Kolobok).Life == 0)
                    {
                        (sender as Kolobok).Die();
                    }

                    (sender as Kolobok).OnReplaceNeeded();
                }

                if (sender is Rocket)
                {
                    ((Rocket)sender).Die();
                    this.Life--;
                    if (this.Life == 0)
                    {
                        this.Die();
                    }
                    else
                    {
                        this.OnReplaceNeeded();
                    }
                }
            }
        }
    }
}
