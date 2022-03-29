using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    public class Plateau : IPlateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau(int width = 0, int height = 0)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{this.Width} {this.Height}";
        }

    }
}
