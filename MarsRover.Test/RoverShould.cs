using MarsRover.Logic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;
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
            var location = new Coordinate();
            location.SetXCoordinate(initialX);
            location.SetYCoordinate(initialY);
            
            var rover = new Rover(location, initialDirection);
            rover.MoveForward();
            
            Assert.Equal(expectedX, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(expectedY, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        [Theory]
        [InlineData(1,1,DirectionEnum.North, 1,2, DirectionEnum.North)]
        [InlineData(1,3,DirectionEnum.South, 1,2, DirectionEnum.South)]
        [InlineData(4,1,DirectionEnum.East, 3,1, DirectionEnum.East)]
        [InlineData(2,1,DirectionEnum.West, 3,1, DirectionEnum.West)]
        public void MoveBackward(int initialX, int initialY, char initialDirection, int expectedX, int expectedY, char expectedDirection)
        {
            var location = new Coordinate();
            location.SetXCoordinate(initialX);
            location.SetYCoordinate(initialY);
            
            var rover = new Rover(location, initialDirection);
            rover.MoveBackward();
            
            Assert.Equal(expectedX, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(expectedY, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        [Theory]
        [InlineData(DirectionEnum.North, DirectionEnum.East)]
        [InlineData(DirectionEnum.East, DirectionEnum.South)]
        [InlineData(DirectionEnum.South, DirectionEnum.West)]
        [InlineData(DirectionEnum.West, DirectionEnum.North)]
        public void TurnRight(char initialDirection, char expectedDirection)
        {
            const int xCoordinate = 2;
            const int yCoordinate = 2;
            var location = new Coordinate();
            location.SetXCoordinate(xCoordinate);
            location.SetYCoordinate(yCoordinate);
            
            var rover = new Rover(location, initialDirection);
            rover.TurnRight();
            
            Assert.Equal(xCoordinate, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(yCoordinate, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }
        
        [Theory]
        [InlineData(DirectionEnum.East, DirectionEnum.North)]
        [InlineData(DirectionEnum.South, DirectionEnum.East)]
        [InlineData(DirectionEnum.West, DirectionEnum.South)]
        [InlineData(DirectionEnum.North, DirectionEnum.West)]
        public void TurnLeft(char initialDirection, char expectedDirection)
        {
            const int xCoordinate = 2;
            const int yCoordinate = 2;
            var location = new Coordinate();
            location.SetXCoordinate(xCoordinate);
            location.SetYCoordinate(yCoordinate);
            
            var rover = new Rover(location, initialDirection);
            rover.TurnLeft();
            
            Assert.Equal(xCoordinate, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(yCoordinate, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }
    }
}