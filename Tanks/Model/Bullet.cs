using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bullet:MovingObject
    {
        public Bullet (int x, int y, int travelDirection)
        {
            X = x;
            Y = y;
            OldX = x;
            OldY = y;
            TravelDirection = travelDirection;
            Speed = 4;
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
            return "Bullet";
        }
    }
}
