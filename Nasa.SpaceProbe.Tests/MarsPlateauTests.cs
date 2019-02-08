namespace Nasa.SpaceProbe.Tests
{
    using Nasa.SpaceProbe.Core.Entities;
    using Xunit;

    public class MarsPlateauTests
    {
        MarsPlateau marsPlateau;

        public MarsPlateauTests()
        {
            marsPlateau = new MarsPlateau();
        }

        [Theory]
        [InlineData(5, 5)]
        public void SetValidPlateauSize(int height, int width)
        {
            marsPlateau.SetSize(height, width);
            
            Assert.Equal(marsPlateau.Size.Height, height);
            Assert.Equal(marsPlateau.Size.Width, width);
        }

        [Theory]
        [InlineData(-1, 5)]
        [InlineData(5, -1)]
        public void SetInvalidPlateauSize(int height, int width)
        {
            marsPlateau.SetSize(height, width);
            Assert.Null(marsPlateau.Size);
        }
    }
}