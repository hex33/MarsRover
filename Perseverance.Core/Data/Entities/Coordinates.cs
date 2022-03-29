using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    public class Coordinates : ICoordinates, ICloneable
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public Coordinates(int x = 0, int y = 0, Direction direction = Direction.N)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public object Clone()
        {
            return new Coordinates { Direction = Direction, X = X, Y = Y };
        }
    }
}
