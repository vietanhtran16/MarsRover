using MarsRover.Logic;
using Xunit;

namespace MarsRover.Test
{
    public class RoverShould
    {
        [Theory]
        [InlineData(1,1,DirectionEnum.South, 1,2, DirectionEnum.South)]
        [InlineData(1,2,DirectionEnum.North, 1,1, DirectionEnum.North)]
        [InlineData(2,1,DirectionEnum.West, 1,1, DirectionEnum.West)]
        [InlineData(1,1,DirectionEnum.East, 2,1, DirectionEnum.East)]
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

        [Theory]
        [InlineData(1,1,DirectionEnum.North, 1,2, DirectionEnum.North)]
        [InlineData(1,3,DirectionEnum.South, 1,2, DirectionEnum.South)]
        [InlineData(4,1,DirectionEnum.East, 3,1, DirectionEnum.East)]
        [InlineData(2,1,DirectionEnum.West, 3,1, DirectionEnum.West)]
        public void MoveBackward(int initialX, int initialY, char initialDirection, int expectedX, int expectedY, char expectedDirection)
        {
            var location = new Location();
            location.SetXCoordinate(initialX);
            location.SetYCoordinate(initialY);
            location.SetDirection(initialDirection);
            
            var rover = new Rover(location);
            rover.MoveBackward();
            
            Assert.Equal(expectedX, rover.GetLocation().GetXCoordinate());
            Assert.Equal(expectedY, rover.GetLocation().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetLocation().GetDirection());
        }

        [Theory]
        [InlineData(DirectionEnum.North, DirectionEnum.East)]
        [InlineData(DirectionEnum.East, DirectionEnum.South)]
        [InlineData(DirectionEnum.South, DirectionEnum.West)]
        [InlineData(DirectionEnum.West, DirectionEnum.North)]
        public void TurnRight(char initialDirection, char expectedDirection)
        {
            var xCoordinate = 2;
            var yCoordinate = 2;
            var location = new Location();
            location.SetXCoordinate(xCoordinate);
            location.SetYCoordinate(yCoordinate);
            location.SetDirection(initialDirection);
            
            var rover = new Rover(location);
            rover.TurnRight();
            
            Assert.Equal(xCoordinate, rover.GetLocation().GetXCoordinate());
            Assert.Equal(yCoordinate, rover.GetLocation().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetLocation().GetDirection());
        }
    }
}