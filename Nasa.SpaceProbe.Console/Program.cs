namespace Nasa.SpaceProbe.Console
{
    using Nasa.SpaceProbe.Core.Entities;
    using Nasa.SpaceProbe.Core.Parser;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.Extensions.Logging;
    using Nasa.SpaceProbe.Core.Interface;

    public class Program
    {
        //public ILogger<MarsPlateau> marsPlateauLogger;

        public static void Main(string[] args)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            
            var marsPlateauLogger = loggerFactory.CreateLogger<MarsPlateau>();

            var marsPlateau = new MarsPlateau(marsPlateauLogger);
            List<CommandParser> parsedCommands = new List<CommandParser>();

            var consoleRead = "initial";
            while (!string.IsNullOrEmpty(consoleRead))
            {
                consoleRead = Console.ReadLine();
                if (!string.IsNullOrEmpty(consoleRead)) parsedCommands.Add(new CommandParser(consoleRead));
            }

            marsPlateau.SetSize(parsedCommands[0].Size.Height, parsedCommands[0].Size.Width);
            var spaceProbe = new SpaceProbe();
            spaceProbe.Land(marsPlateau, parsedCommands[1].Position, parsedCommands[1].Direction);
            spaceProbe.Move(parsedCommands[2].Movements);

            Console.WriteLine(spaceProbe.Location());

            Console.WriteLine("End");
            Console.ReadLine();
            //foreach (var command in args)
            //{
            //    if (parser.Size != null && parser.Position != null && parser.Movements != null)
            //        parser = new CommandParser(command);
            //    if (parser.Size != null)
            //    {
            //        marsPlateau.SetSize(parser.Size);
            //    }
            //    else if (parser.Position != null && parser.Movements != null)
            //    {
            //        var spaceProbe = new SpaceProbe();
            //        spaceProbe.Land(marsPlateau, parser.Position, parser.Direction);
            //        spaceProbe.Move(parser.Movements);
            //    }
            //}
        }

    }
}
