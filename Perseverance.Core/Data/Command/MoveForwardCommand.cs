using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perseverance.Core.Data.Command
{
    public class MoveForwardCommand : ICommand, IPreCommand
    {
        public bool Eligibility(Plateau plateau, Coordinates coordinate, List<Coordinates> coordinates)
        {
            Coordinates newCoordinate = coordinate.Clone() as Coordinates;
            this.Execute(newCoordinate);
            return (newCoordinate.X <= plateau.Width
                && newCoordinate.Y <= plateau.Height
                && newCoordinate.X >= 0
                && newCoordinate.Y >= 0
                && !coordinates.Any(p => p.X == newCoordinate.X && p.Y == newCoordinate.Y));
        }

        public void Execute(ICoordinates currentCoordinates)
        {
            switch (currentCoordinates.Direction)
            {
                case Direction.N:
                    currentCoordinates.Y++;
                    break;
                case Direction.E:
                    currentCoordinates.X++;
                    break;
                case Direction.S:
                    currentCoordinates.Y--;
                    break;
                case Direction.W:
                    currentCoordinates.X--;
                    break;
            }
        }
    }
}
