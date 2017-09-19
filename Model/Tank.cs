using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Model
{
    public class Tank:MovingObject
    {
        private int count = 0;
        public Tank(int x, int y)
        {
            X = x;
            Y = y;
            OldX = x;
            OldY = y;
            TravelDirection = 2;
            Speed = 1;
        }
        public void Move()
        {
            if (!Collision())
            {
                count++;
                switch (TravelDirection)
                {
                    case 1:
                        OldY = Y;
                        OldX = X;
                        Y -= Speed;
                        break;
                    case 2:
                        OldX = X;
                        OldY = Y;
                        Y += Speed;
                        break;
                    case 3:
                        OldX = X;
                        OldY = Y;
                        X -= Speed;
                        break;
                    case 4:
                        OldX = X;
                        OldY = Y;
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
        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }
        public override string ToString()
        {
            return "Tank";
        }
    }


}
