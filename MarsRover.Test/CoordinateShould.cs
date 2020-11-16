using MarsRover.Logic.DTO;
using Xunit;

namespace MarsRover.Test
{
    public class CoordinateShould
    {
        [Fact]
        public void SetInitialCoordinate()
        {
            var coordinate = new Coordinate(5,6);
            
            Assert.Equal(5, coordinate.GetXCoordinate());
            Assert.Equal(6, coordinate.GetYCoordinate());
        }
        
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
