using MarsRover.Logic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverShould
    {
        [Theory]
        [InlineData(1,1,DirectionEnum.South, 2,1, DirectionEnum.South)]
        [InlineData(2,1,DirectionEnum.North, 1,1, DirectionEnum.North)]
        [InlineData(1,2,DirectionEnum.West, 1,1, DirectionEnum.West)]
        [InlineData(1,1,DirectionEnum.East, 1,2, DirectionEnum.East)]
        public void MoveForward(int initialX, int initialY, char initialDirection, int expectedX, int expectedY, char expectedDirection)
        {
            var location = new Location();
            location.SetXCoordinate(initialX);
            location.SetYCoordinate(initialY);
            location.SetDirection(initialDirection);
            
            var rover = new Rover(location);
            rover.MoveForward();
            
            Assert.Equal(expectedX, rover.GetLocation().GetXCoordinate());
            Assert.Equal(expectedY, rover.GetLocation().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetLocation().GetDirection());
        }
    }
}