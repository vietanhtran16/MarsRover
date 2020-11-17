using System;
using System.Collections.Generic;
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
            var coordinate = new Coordinate(initialX, initialY);
            var world = new World(5, 5);
            var rover = new Rover(coordinate, initialDirection, world);
            
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
            var coordinate = new Coordinate(initialX, initialY);
            var world = new World(5, 5);
            var rover = new Rover(coordinate, initialDirection, world);
            
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
            var world = new World(5, 5);
            var coordinate = new Coordinate(xCoordinate, yCoordinate);
            var rover = new Rover(coordinate, initialDirection, world);
            
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
            var coordinate = new Coordinate(xCoordinate, yCoordinate);
            var world = new World(5, 5);
            var rover = new Rover(coordinate, initialDirection, world);
            
            rover.TurnLeft();
            
            Assert.Equal(xCoordinate, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(yCoordinate, rover.GetCoordinate().GetYCoordinate());
            Assert.Equal(expectedDirection, rover.GetDirection());
        }

        [Theory]
        [MemberData(nameof(NotMoveForwardIfThereIsObstacleTestData))]
        public void NotMoveForwardIfThereIsObstacle(int xCoord, int yCoord, char direction, World world, Coordinate obstacle)
        {
            var coordinate = new Coordinate(xCoord, yCoord);
            world.SetObstacle(obstacle);
            var rover = new Rover(coordinate, direction, world);
            
            var exception = Assert.Throws<Exception>(() => rover.MoveForward());
            
            Assert.Equal($"Bump into obstacle at {obstacle.GetXCoordinate()},{obstacle.GetYCoordinate()}", exception.Message);
            Assert.Equal(xCoord, rover.GetCoordinate().GetXCoordinate());
            Assert.Equal(yCoord, rover.GetCoordinate().GetYCoordinate());
        }
        
        public static IEnumerable<object[]> NotMoveForwardIfThereIsObstacleTestData =>
            new List<object[]>
            {
                new object[] { 1,1,DirectionEnum.South, new World(5, 5), new Coordinate(1,2) },
                new object[] { 1,2,DirectionEnum.North, new World(5, 5), new Coordinate(1,1) },
                new object[] { 1,1,DirectionEnum.East, new World(5, 5), new Coordinate(2,1) },
                new object[] { 2,1,DirectionEnum.West, new World(5, 5), new Coordinate(1,1) }
            };
    }
}