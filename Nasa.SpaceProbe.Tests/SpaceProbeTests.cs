namespace Nasa.SpaceProbe.Tests
{
    using Nasa.SpaceProbe.Core.Auxiliar;
    using Nasa.SpaceProbe.Core.Entities;
    using Xunit;

    public class SpaceProbeTests
    {
        public SpaceProbeTests()
        {

        }

        [Theory]
        [InlineData(2, 2, CardinalDirections.North)]
        public void LandOnValidPosition(int width, int height, CardinalDirections direction)
        {
            var marsPlateau = new MarsPlateau();
            var spaceProbe = new SpaceProbe();

            marsPlateau.SetSize(10, 10);

            spaceProbe.Land(marsPlateau, new Position(width, height), direction);

            Assert.Equal(spaceProbe.Position.XAxis, width);
            Assert.Equal(spaceProbe.Position.YAxis, height);
        }

        [Theory]
        [InlineData(2, 2, CardinalDirections.North)]
        public void LandOnInvalidPosition(int width, int height, CardinalDirections direction)
        {
            var marsPlateau = new MarsPlateau();
            var spaceProbe = new SpaceProbe();

            marsPlateau.SetSize(1, 1);

            spaceProbe.Land(marsPlateau, new Position(width, height), direction);

            Assert.Null(spaceProbe.Position);
        }

        [Theory]
        [InlineData(CardinalDirections.North, CardinalDirections.West)]
        [InlineData(CardinalDirections.West, CardinalDirections.South)]
        [InlineData(CardinalDirections.South, CardinalDirections.East)]
        [InlineData(CardinalDirections.East, CardinalDirections.North)]
        public void TurnLeft(CardinalDirections initial, CardinalDirections expected)
        {
            var spaceProbe = new SpaceProbe();
            spaceProbe.Direction = initial;

            spaceProbe.LeftRotation();

            Assert.Equal(expected, spaceProbe.Direction);
        }

        [Theory]
        [InlineData(CardinalDirections.North, CardinalDirections.East)]
        [InlineData(CardinalDirections.East, CardinalDirections.South)]
        [InlineData(CardinalDirections.South, CardinalDirections.West)]
        [InlineData(CardinalDirections.West, CardinalDirections.North)]
        public void TurnRight(CardinalDirections initial, CardinalDirections expected)
        {
            var spaceProbe = new SpaceProbe();
            spaceProbe.Direction = initial;

            spaceProbe.RightRotation();

            Assert.Equal(expected, spaceProbe.Direction);
        }

        [Theory]
        [InlineData(CardinalDirections.North, 2, 3)]
        [InlineData(CardinalDirections.East, 3, 2)]
        [InlineData(CardinalDirections.South, 2, 1)]
        [InlineData(CardinalDirections.West, 1, 2)]
        public void MoveForward(CardinalDirections direction,int expectedXAxis, int expectedYAxis)
        {
            
            var spaceProbe = new SpaceProbe();
            spaceProbe.Position = new Position(2, 2);
            spaceProbe.Direction = direction;

            var marsPlateau = new MarsPlateau();
            marsPlateau.SetSize(3, 3);
            spaceProbe.PlateauLanded = marsPlateau;

            spaceProbe.MoveForward();

            Assert.Equal(spaceProbe.Position.XAxis, expectedXAxis);
            Assert.Equal(spaceProbe.Position.YAxis, expectedYAxis);
        }
    }
}
