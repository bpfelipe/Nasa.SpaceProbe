namespace Nasa.SpaceProbe.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct Size
    {
        public int Height { get; set; }
        public int Width { get; set; }

        public Size(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }

    public class MarsPlateau
    {
        public Size Size { get; private set; }

        public void SetSize(int height, int width)
        {
            Size = new Size(height, width);
        }
    }
}
