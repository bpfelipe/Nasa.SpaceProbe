namespace Nasa.SpaceProbe.Core.Entities
{
    using Nasa.SpaceProbe.Core.Auxiliar;
    using Nasa.SpaceProbe.Core.Interface;
    using System;

    public class MarsPlateau : IMarsPlateau
    {
        public Size Size { get; set; }

        public void SetSize(int height, int width)
        {
            if (height < 1 || width < 1) Console.WriteLine("Invalid Size.");
            else Size = new Size(height, width);
        }
    }
}
