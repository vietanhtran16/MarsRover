namespace MarsRover.Logic
{
    public class Coordinate
    {
        private int _xCoordinate;
        private int _yCoordinate;
        private char _direction;
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

        public void SetDirection(char direction)
        {
            _direction = direction;
        }

        public char GetDirection()
        {
            return _direction;
        }
    }
}