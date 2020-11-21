using MarsRover.Logic;
using MarsRover.Logic.Enums;
using MarsRover.Logic.Interfaces;
using Moq;
using Xunit;

namespace MarsRover.Test
{
    public class DriverShould
    {
        [Fact]
        public void IssueTwoCommandsToRover()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);
            
            driver.IssueCommands($"{CommandEnum.Forward}{CommandEnum.Backward}");
            
            mockRover.Verify(rover => rover.MoveForward(), Times.Once);
            mockRover.Verify(rover => rover.MoveBackward(), Times.Once);
        }
        
        [Fact]
        public void IssueMultipleComplexCommandsToRover()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);
            
            driver.IssueCommands($"{CommandEnum.Forward}{CommandEnum.Left}{CommandEnum.Backward}{CommandEnum.Right}{CommandEnum.Forward}");
            
            mockRover.Verify(rover => rover.MoveForward(), Times.Exactly(2));
            mockRover.Verify(rover => rover.TurnLeft(), Times.Once);
            mockRover.Verify(rover => rover.MoveBackward(), Times.Once);
            mockRover.Verify(rover => rover.TurnRight(), Times.Once);
        }
        
        [Fact]
        public void IssueCommandToMoveForward()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);

            driver.IssueCommand(CommandEnum.Forward);
            
            mockRover.Verify(rover => rover.MoveForward(), Times.Once);
        }
        
        [Fact]
        public void IssueCommandToMoveBackward()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);

            driver.IssueCommand(CommandEnum.Backward);
            
            mockRover.Verify(rover => rover.MoveBackward(), Times.Once);
        }
        
        [Fact]
        public void IssueCommandTurnRight()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);

            driver.IssueCommand(CommandEnum.Right);
            
            mockRover.Verify(rover => rover.TurnRight(), Times.Once);
        }
        
        [Fact]
        public void IssueCommandTurnLeft()
        {
            var mockRover = new Mock<IRover>();
            var driver = new Driver(mockRover.Object);

            driver.IssueCommand(CommandEnum.Left);
            
            mockRover.Verify(rover => rover.TurnLeft(), Times.Once);
        }
    }
}