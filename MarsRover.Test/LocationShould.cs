using MarsRover.Logic;
using Xunit;

namespace MarsRover.Test
{
    public class LocationShould
    {
        [Fact]
        public void SetXCoordinate()
        {
            var coordinate = new Location();

            coordinate.SetXCoordinate(1);
            
            Assert.Equal(1, coordinate.GetXCoordinate());
        }
        
        [Fact]
        public void SetYCoordinate()
        {
            var coordinate = new Location();

            coordinate.SetYCoordinate(1);
            
            Assert.Equal(1, coordinate.GetYCoordinate());
        }
        
        [Fact]
        public void SetDirection()
        {
            var coordinate = new Location();

            coordinate.SetDirection('S');
            
            Assert.Equal('S', coordinate.GetDirection());
        }
    }
}
