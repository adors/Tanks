using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using Tanks.MVC;

namespace Tanks
{
    public class Apple : MapObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Apple(Point position, int id) : base(position)
        {
            this.id = id;
        }

        public Apple()
        {
        }

        private void Replace()
        {
            OnReplaceNeeded();
        }

        public override void OnCheckPosition(object sender, EventArgs e)
        {
            PositionChangedEventArgs positionArgs = e as PositionChangedEventArgs;
            if (positionArgs == null)
                return;
            if (CollidesWith(positionArgs.NewRectangle))
            {
                if (sender is Kolobok)
                {
                    OnReplaceNeeded();
                }
            }
        }

    }
}
