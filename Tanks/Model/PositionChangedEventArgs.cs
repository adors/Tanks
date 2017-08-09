using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Tanks.MVC
{
    public class PositionChangedEventArgs : EventArgs
    {
        private Rectangle newRectangle;

        public Rectangle NewRectangle
        {
            get { return newRectangle; }
            set { newRectangle = value; }
        }
        public PositionChangedEventArgs() : base()
        {
        }
        public PositionChangedEventArgs(Rectangle newRectangle)
            : base()
        {
            this.newRectangle = newRectangle;
        }
    }
}
