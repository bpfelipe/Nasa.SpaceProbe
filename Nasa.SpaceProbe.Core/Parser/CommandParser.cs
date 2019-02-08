namespace Nasa.SpaceProbe.Core.Parser
{
    using Nasa.SpaceProbe.Core.Auxiliar;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CommandParser
    {
        public Size Size { get; private set; }
        public Position Position { get; private set; }
        public List<Movements> Movements { get; set; }
        public CardinalDirections Direction { get; private set; }
        public CommandType CommandType { get; private set; }


        public CommandParser(string command)
        {
            if (Regex.Match(command, "^([0-9]+ [0-9]+)$").Success)
            {
                Console.WriteLine("CommandParser - New Plateau Detected");

                CommandType = CommandType.CreatePlateau;
                var sizeDefinition = command.Split(' ').Select(x => int.Parse(x)).ToArray();

                Size = new Size(sizeDefinition[0], sizeDefinition[1]);

                Console.WriteLine(string.Format("CommandParser - Plateau size detected: {0} {1}", Size.Height, Size.Width));
            }
            else if (Regex.Match(command, "^([0-9]+ [0-9]+ (N|S|E|W))$").Success)
            {
                Console.WriteLine("CommandParser - New Probe Detected");
                CommandType = CommandType.Land;
                var positionDefinition = command.Split(' ').ToArray();
                Position = new Position(int.Parse(positionDefinition[0]), int.Parse(positionDefinition[1]));
                switch (Convert.ToChar(positionDefinition[2]))
                {
                    case 'N':
                        Direction = CardinalDirections.North;
                        break;
                    case 'E':
                        Direction = CardinalDirections.East;
                        break;
                    case 'S':
                        Direction = CardinalDirections.South;
                        break;
                    case 'W':
                        Direction = CardinalDirections.West;
                        break;
                    default:
                        break;
                }

                Console.WriteLine(string.Format("CommandParser - Probe landed on: XAxis:{0} | YAxis: {1} | Direction: {2}", Position.XAxis, Position.YAxis, Direction));
            }
            else if (Regex.Match(command, @"^((L|R|M)+)$").Success)
            {
                CommandType = CommandType.Move;

                List<Movements> movements = new List<Movements>();

                foreach (var move in command.ToCharArray())
                {
                    switch (move)
                    {
                        case 'M':
                            movements.Add(Auxiliar.Movements.Forward);
                            break;
                        case 'L':
                            movements.Add(Auxiliar.Movements.Left);
                            break;
                        case 'R':
                            movements.Add(Auxiliar.Movements.Right);
                            break;
                        default:
                            break;
                    }
                }
                Movements = movements;
            }
            else
            {
                Console.WriteLine("Invalid Command!");
            }
        }
    }
}
