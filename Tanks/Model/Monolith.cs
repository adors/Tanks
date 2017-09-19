using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Monolith:StaticObject
    {
        public Monolith(int x, int y)
        {
            X = x;
            Y = y;
        }
        public override string ToString()
        {
            return "Monolith";
        }
    }

    
}
