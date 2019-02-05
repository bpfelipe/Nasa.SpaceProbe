namespace Nasa.SpaceProbe.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class MarsPlateauTests
    {
        private readonly MarsPlateau;

        [InlineData(5, 5)]
        public void SetSize(int height, int width)
        {
            marsPlateau.SetSize(height, width);
            Assert.Equals(marsPlateau.Size, new Size(height, width));
        }
    }
}