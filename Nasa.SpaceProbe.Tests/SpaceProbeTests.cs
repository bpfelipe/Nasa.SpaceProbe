namespace Nasa.SpaceProbe.Tests
{
    using Nasa.SpaceProbe.Core.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Xunit;

    public class SpaceProbeTests
    {
        public SpaceProbe SpaceProbe { get; set; }
        public MarsPlateau MarsPlateau { get; set; }

        public SpaceProbeTests()
        {
            SpaceProbe = new SpaceProbe();
            //MarsPlateau = new MarsPlateau();
        }

        public void SetPosition(int width, int height, char direction)
        {

        }

        public void TurnLeft()
        {
        }
        public void TurnRight()
        {
        }
        public void Move()
        {
        }
    }
}
