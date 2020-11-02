using MarsRover.Logic;
using Xunit;

namespace MarsRover.Test
{
    public class CoordinateShould
    {
        [Fact]
        public void SetXCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetX(1);
            
            Assert.Equal(1, coordinate.GetX());
        }
        
        [Fact]
        public void SetYCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetY(1);
            
            Assert.Equal(1, coordinate.GetY());
        }
    }
}
