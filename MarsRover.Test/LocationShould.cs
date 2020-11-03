using MarsRover.Logic;
using Xunit;

namespace MarsRover.Test
{
    public class LocationShould
    {
        [Fact]
        public void SetXCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetXCoordinate(1);
            
            Assert.Equal(1, coordinate.GetXCoordinate());
        }
        
        [Fact]
        public void SetYCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetYCoordinate(1);
            
            Assert.Equal(1, coordinate.GetYCoordinate());
        }
    }
}
