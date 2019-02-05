namespace Nasa.SpaceProbe.Tests
{
    using Nasa.SpaceProbe.Core.Entities;
    using Xunit;

    public class MarsPlateauTests
    {
        public MarsPlateau MarsPlateau { get; set; }


        public MarsPlateauTests()
        {
            MarsPlateau = new MarsPlateau();
        }

        [Theory]
        [InlineData(5, 5)]
        public void SetSize(int height, int width)
        {
            MarsPlateau.SetSize(height, width);
            Assert.Equal(MarsPlateau.Size, new Size(height, width));
        }
    }
}