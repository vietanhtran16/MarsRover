using MarsRover.Logic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;
using Xunit;

namespace MarsRover.Test
{
    public class DriverShould
    {
        [Theory]
        [InlineData(CommandEnum.Forward, 4, 3, DirectionEnum.East)]
        [InlineData(CommandEnum.Backward, 2, 3, DirectionEnum.East)]
        [InlineData(CommandEnum.Right, 3, 3, DirectionEnum.South)]
        [InlineData(CommandEnum.Left, 3, 3, DirectionEnum.North)]
        public void IssueCommandToRoverToMove(char commandEnum, int expectedX, int expectedY, char expectedDirection)
        {
            var world = new World(5, 5);
            var rover = new Rover(new Coordinate(3,3), DirectionEnum.East, world);
            var driver = new Driver(rover);

            driver.IssueCommand(commandEnum);
            
            Assert.Equal(expectedX, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(expectedY, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }
    }
}