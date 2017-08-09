using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using Tanks.MVC;

namespace Tanks
{
    public class Kolobok : DynamicMapObject
    {
        public override void Run()
        {
            OnCheck();
            Move();
        }

        public Kolobok() : base()
        {
        }

        public Kolobok(Point position) : base(position)
        {
            Life = 3;
        }
    }
}
