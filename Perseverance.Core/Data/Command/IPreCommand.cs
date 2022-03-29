using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core.Data.Command
{
    public interface IPreCommand
    {
        bool Eligibility(Plateau plateau, Coordinates coordinate, List<Coordinates> roverCoordinates);
    }
}
