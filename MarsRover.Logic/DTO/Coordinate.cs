namespace MarsRover.Logic.DTO
{
    public class Coordinate
    {
        private readonly int _xCoordinate;
        private readonly int _yCoordinate;
        
        public Coordinate()
        {
        }

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        public int GetXCoordinate()
        {
            return _xCoordinate;
        }

        public int GetYCoordinate()
        {
            return _yCoordinate;
        }
    }
}