namespace Nasa.SpaceProbe.Tests
{
    using Microsoft.Extensions.Logging;
    using Moq;
    using Nasa.SpaceProbe.Core.Auxiliar;
    using Nasa.SpaceProbe.Core.Entities;
    using Xunit;

    public class MarsPlateauTests
    {
        ILogger<MarsPlateau> logger;
        MarsPlateau marsPlateau;

        public MarsPlateauTests()
        {
            logger = new Mock<ILogger<MarsPlateau>>().Object;
            marsPlateau = new MarsPlateau(logger);
        }

        [Theory]
        [InlineData(5, 5)]
        public void SetValidPlateauSize(int height, int width)
        {
            marsPlateau.SetSize(height, width);
            
            Assert.Equal(marsPlateau.Size.Height, height);
            Assert.Equal(marsPlateau.Size.Width, width);
        }
    }
}