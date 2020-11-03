using System.Collections.Generic;
using MarsRover.Logic;
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
            var obstacle = new Coordinate();
            obstacle.SetXCoordinate(1);
            obstacle.SetYCoordinate(5);
            var world = new World(5, 5);

            world.SetObstacle(obstacle);
            
            var expectedObstacles = new List<Coordinate>() { obstacle };
            Assert.Equal(expectedObstacles, world.GetObstacles());
        }
    }
}