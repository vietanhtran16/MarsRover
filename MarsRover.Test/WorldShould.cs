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
    }
}