using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core
{
    internal class RegularExpressions
    {
        internal const string PlateauEndRegEx = @"^\d{1,2} \d{1,2}$";
        internal const string RoverCoordinatesRegEx = @"^\d{1,2} \d{1,2} [N,S,E,W]$";
        internal const string RoverCommandRegEx = @"^[L,R,M]+$";
    }
}
