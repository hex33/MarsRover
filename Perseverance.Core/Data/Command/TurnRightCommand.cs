using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core.Data.Command
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(ICoordinates currentCoordinates)
        {
            int direction = (int)++currentCoordinates.Direction;
            currentCoordinates.Direction = direction > 3 ? Direction.N : (Direction)direction;
        }
    }
}
