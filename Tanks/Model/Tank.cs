using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using MVC;
namespace Tanks
{
    public class Tank : DynamicMapObject
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Tank()
        {
        }

        public Tank(Point position, int id) : base(position)
        {
            this.id = id;
            Life = 1;
        }
    }
}
