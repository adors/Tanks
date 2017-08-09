using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using Tanks.MVC;
using Tanks.Model;

namespace Tanks
{
    public class MapObject
    {
        protected Point position;
        protected Random rand = new Random(DateTime.Now.Millisecond);

        protected int width = 25;
        protected int height = 25;
        protected bool alive;

        private int life;
        private Point mapSize;

        public event EventHandler Died;
        public event EventHandler Hited;

        public Point Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPositionChanged();

            }
        }

        public int Life
        {
            get { return life; }
            set { life = value; }
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public Point MapSize
        {
            get { return mapSize; }
            set { mapSize = value; }
        }

        public bool Alive
        {
            get { return alive; }
        }

        public MapObject()
        {
        }
        
        public MapObject(Point position)
        {
            Position = position;
            alive = true;
        }

        public event EventHandler ReplaceNeeded;

        public void OnReplaceNeeded()
        {
            if (ReplaceNeeded != null)
                ReplaceNeeded(this, new EventArgs());
        }

        protected bool CheckCrossing(Point p)
        {
            if (this.Position.X + this.Width >= p.X && this.Position.X <= p.X)
            {
                if (this.Position.Y + this.Height >= p.Y && this.Position.Y <= p.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public void Die()
        {
            alive = false;
            OnDied();
        }

        protected virtual void OnDied()
        {
            if (Died != null)
                Died(this, new EventArgs());
        }

        public void GetHit()
        {
            OnHited();
        }

        protected virtual void OnHited()
        {
            if (Hited != null)
                Hited(this, new EventArgs());
        }

        public bool CollidesWith(Rectangle rect)
        {
            if (CheckCrossing(new Point(rect.Left, rect.Top)) ||
                CheckCrossing(new Point(rect.Right, rect.Top)) ||
                CheckCrossing(new Point(rect.Right, rect.Bottom)) ||
                CheckCrossing(new Point(rect.Left, rect.Bottom)))
                return true;

            return false;
        }

        public virtual void OnCheckPosition(object sender, EventArgs e)
        {
            PositionChangedEventArgs positionArgs = e as PositionChangedEventArgs;
            if (positionArgs == null)
                return;
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if (sender is Rocket)
                {
                    (sender as Rocket).Die();
                }
                else
                {
                    ((DynamicMapObject)sender).Deviate();
                }
            }
        }

        public event EventHandler PositionChanged;
        protected virtual void OnPositionChanged()
        {
            if (PositionChanged != null)
                PositionChanged(this, new EventArgs());
        }
    }
}
