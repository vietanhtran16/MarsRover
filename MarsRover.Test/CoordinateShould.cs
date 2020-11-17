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
    }
}
