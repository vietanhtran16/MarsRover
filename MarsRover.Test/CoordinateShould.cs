using MarsRover.Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRover.Test
{
    [TestClass]
    public class CoordinateShould
    {
        [TestMethod]
        public void SetXCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetX(1);
            
            Assert.AreEqual(1, coordinate.GetX());
        }
        
        [TestMethod]
        public void SetYCoordinate()
        {
            var coordinate = new Coordinate();

            coordinate.SetY(1);
            
            Assert.AreEqual(1, coordinate.GetY());
        }
    }
}
