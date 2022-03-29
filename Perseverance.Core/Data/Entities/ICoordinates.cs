using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    public interface ICoordinates
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
    }
}
