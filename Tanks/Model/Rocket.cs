using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks.Model
{
    class Rocket : DynamicMapObject
    {
        public Rocket()
        {
        }

        public Rocket(Point position, int dir) : base(position)
        {
            DirectionNow = dir;
            height = 3;
            width = 3;
            delta = 3;
            Life = 1;
            IdentifyDirection(dir);
        }
    }
}
