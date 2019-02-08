namespace Nasa.SpaceProbe.Console
{
    using Nasa.SpaceProbe.Core.Entities;
    using Nasa.SpaceProbe.Core.Parser;
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            var marsPlateau = new MarsPlateau();
            List<SpaceProbe> probeList = new List<SpaceProbe>();
            var probe = new SpaceProbe();
            var consoleRead = "initial";
            while (true)
            {
                consoleRead = Console.ReadLine();

                if (!string.IsNullOrEmpty(consoleRead))
                {
                    var command = new CommandParser(consoleRead);
                    if (command.CommandType == Core.Auxiliar.CommandType.CreatePlateau)
                    {
                        marsPlateau.SetSize(command.Size.Height, command.Size.Width);
                    }
                    else if (command.CommandType == Core.Auxiliar.CommandType.Land)
                    {
                        probe = new SpaceProbe();
                        probeList.Add(probe);
                        probe.Land(marsPlateau, command.Position, command.Direction);
                    }
                    else if (command.CommandType == Core.Auxiliar.CommandType.Move)
                    {
                        probe.Move(command.Movements);
                    }
                }
                else
                {
                    foreach (var item in probeList)
                    {
                        Console.WriteLine(item.Location());
                    }
                }
            }
        }
    }
}
