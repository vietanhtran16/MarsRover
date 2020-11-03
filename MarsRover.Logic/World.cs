namespace MarsRover.Logic
{
    public class World
    {
        private int _width;
        private int _height;
        public World(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }
    }
}