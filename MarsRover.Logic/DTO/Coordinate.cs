namespace MarsRover.Logic.DTO
{
    public class Coordinate
    {
        private int _xCoordinate;
        private int _yCoordinate;
        
        public Coordinate()
        {
        }

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            _xCoordinate = xCoordinate;
            _yCoordinate = yCoordinate;
        }

        public void SetXCoordinate(int value)
        {
            _xCoordinate = value;
        }

        public int GetXCoordinate()
        {
            return _xCoordinate;
        }

        public void SetYCoordinate(int value)
        {
            _yCoordinate = value;
        }

        public int GetYCoordinate()
        {
            return _yCoordinate;
        }
    }
}