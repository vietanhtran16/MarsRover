namespace MarsRover.Logic
{
    public class Coordinate
    {
        private int _x;
        private int _y;
        public void SetX(int value)
        {
            _x = value;
        }

        public int GetX()
        {
            return _x;
        }

        public void SetY(int value)
        {
            _y = value;
        }

        public int GetY()
        {
            return _y;
        }
    }
}