namespace Nasa.SpaceProbe.Core.Entities
{
    using Microsoft.Extensions.Logging;
    using Nasa.SpaceProbe.Core.Auxiliar;
    using Nasa.SpaceProbe.Core.Interface;
    using System;

    public class MarsPlateau : IMarsPlateau
    {
        public readonly ILogger logger;
        public Size Size { get; set; }

        public MarsPlateau(ILogger<MarsPlateau> logger)
        {
            this.logger = logger;
        }

        public void SetSize(int height, int width)
        {
            if (height < 1 || width < 1) logger.LogError("Invalid Size.", height, width);
            Size = new Size(height, width);
        }
    }
}
