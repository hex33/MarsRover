using Perseverance.Core;
using Perseverance.Core.Data.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace Perseverance.Rover
{
    public class RoverEngine
    {
        Plateau plateau = new Plateau();
        List<RoverInfo> roverList = new List<RoverInfo>();
        List<Coordinates> roverLastCoordinates = new List<Coordinates>();

        public string PlateauCreate(string command)
        {
            if (!new Regex(RegularExpressions.PlateauEndRegEx).IsMatch(command))
            {
                throw new ArgumentNullException(ErrorMessage.ER_MATCH_PLATEAU);
            }
            plateau = new Plateau { Width = int.Parse(command.Split(' ')[0]), Height = int.Parse(command.Split(' ')[1]) };
            return plateau.ToString();
        }
        public RoverInfo AddRover(string command)
        {
            var rover = new RoverInfo();
            var sr = new StringReader(command);
            string roverCoordinates = sr.ReadLine();
            if (string.IsNullOrEmpty(roverCoordinates))
                throw new Exception(ErrorMessage.ER_UNDEFINED_COMAND);

            roverCoordinates = roverCoordinates.Trim();
            if (!new Regex(RegularExpressions.RoverCoordinatesRegEx).IsMatch(roverCoordinates))
            {
                throw new Exception(ErrorMessage.ER_MATCH_ROVER_COORDINATE);
            }
            Coordinates coordinate = new Coordinates { X = int.Parse(roverCoordinates.Split(' ')[0]), Y = int.Parse(roverCoordinates.Split(' ')[1]), Direction = (Direction)Enum.Parse(typeof(Direction), roverCoordinates.Split(' ')[2]) };
            rover = new RoverInfo { Id = roverList.Count + 1, Coordinates = coordinate };
            roverList.Add(rover);

            string roverCommand = sr.ReadLine();
            if (string.IsNullOrEmpty(roverCommand))
                throw new Exception(ErrorMessage.ER_UNDEFINED_COMAND);
            roverCommand = roverCommand.Trim();

            if (!new Regex(RegularExpressions.RoverCommandRegEx).IsMatch(roverCommand))
            {
                roverList.Remove(rover);
                throw new Exception(ErrorMessage.ER_MATCH_ROVER_COMAND);
            }
            foreach (char c in roverCommand.ToUpper())
            {
                switch (c)
                {
                    case 'L':
                        rover.Commands.Add(new Core.Data.Command.TurnLeftCommand());
                        break;
                    case 'R':
                        rover.Commands.Add(new Core.Data.Command.TurnRightCommand());
                        break;
                    case 'M':
                        rover.Commands.Add(new Core.Data.Command.MoveForwardCommand());
                        break;
                }
            }
            return rover;
        }
        public string Run(RoverInfo roverInfo)
        {
            if (roverInfo == null)
                throw new Exception(ErrorMessage.ER_ROVER_NOT_FOUND);
            foreach (ICommand cmd in roverInfo.Commands)
            {
                if (cmd is IPreCommand)
                {
                    if (!(cmd as IPreCommand).Eligibility(plateau, roverInfo.Coordinates, roverLastCoordinates))
                        break;
                }
                cmd.Execute(roverInfo.Coordinates);
            }
            roverLastCoordinates.Add(roverInfo.Coordinates);
            return $"{roverInfo.Coordinates.X} {roverInfo.Coordinates.Y} {roverInfo.Coordinates.Direction}";
        }
    }
}
