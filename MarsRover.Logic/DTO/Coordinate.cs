namespace MarsRover.Logic
{
    public class Coordinate
    {
        private int _xCoordinate;
        private int _yCoordinate;
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