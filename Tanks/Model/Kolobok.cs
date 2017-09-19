using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Kolobok:MovingObject
    {
        public Kolobok(int x, int y)
        {
            X = x;
            Y = y;
            OldX = x;
            OldY = y;
            Speed = 1;
            TravelDirection = 2;
        }

        public void Move()
        {
            if (!Collision())
            {
                switch (TravelDirection)
                {
                    case 1:
                        OldY = Y;
                        Y -= Speed;
                        break;
                    case 2:
                        OldY = Y;
                        Y += Speed;
                        break;
                    case 3:
                        OldX = X;
                        X -= Speed;
                        break;
                    case 4:
                        OldX = X;
                        X += Speed;
                        break;
                }
            }
        }

        public override bool Collision()
        {
            return false;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Kolobok";
        }
    }
}
