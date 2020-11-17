using System.Collections.Generic;
using MarsRover.Logic;
using MarsRover.Logic.DTO;
using Xunit;

namespace MarsRover.Test
{
    public class WorldShould
    {
        [Fact]
        public void SetUpWorldWithSize()
        {
            var world = new World(5, 5);
            
            Assert.Equal(5, world.GetWidth());
            Assert.Equal(5, world.GetHeight());
        }
        
        [Fact]
        public void PlaceObstacle()
        {
            var obstacle = new Coordinate(1, 5);
            var world = new World(5, 5);

            world.SetObstacle(obstacle);
            
            var expectedObstacles = new List<Coordinate>() { obstacle };
            Assert.Equal(expectedObstacles, world.GetObstacles());
        }

        [Fact]
        public void ReturnTrueIfCoordinateIsEmpty()
        {
            var obstacle = new Coordinate(1, 5);
            var coordinateToCheck = new Coordinate(1, 1);
            var world = new World(5, 5);
            world.SetObstacle(obstacle);

            var isEmpty = world.IsEmpty(coordinateToCheck);
            
            Assert.True(isEmpty);
        }
        
        [Fact]
        public void ReturnFalseIfCoordinateIsNotEmpty()
        {
            var obstacle = new Coordinate(1, 5);
            var coordinateToCheck = new Coordinate(1, 5);
            var world = new World(5, 5);
            world.SetObstacle(obstacle);

            var isEmpty = world.IsEmpty(coordinateToCheck);
            
            Assert.False(isEmpty);
        }
    }
}