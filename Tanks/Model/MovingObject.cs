using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class MovingObject:StaticObject
    {
        
        private int _speed;
        private int _travelDirection;
        private int _mapHight;
        private int _mapWidth;
        private int _oldX;
        private int _oldY;
        

        public int OldX
        {
            get
            {
                return _oldX;
            }

            set
            {
                _oldX = value;
            }
        }
        public int OldY
        {
            get
            {
                return _oldY;
            }

            set
            {
                _oldY = value;
            }
        }
        public int Speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public int TravelDirection
        {
            get
            {
                return _travelDirection;
            }

            set
            {
                _travelDirection = value;
            }
        }

        public void Turn(int n)
        {
            switch (TravelDirection)
            {
                case 1:
                    TravelDirection = n;
                    break;
                case 2:
                    TravelDirection = n; 
                    break;
                case 3:
                    TravelDirection = n; 
                    break;
                case 4:
                    TravelDirection = n; 
                    break;
            }
        }

        public abstract void Update();

        public abstract bool Collision();
    }
}
