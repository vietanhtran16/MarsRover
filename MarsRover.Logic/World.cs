using System.Collections.Generic;
using System.Linq;
using MarsRover.Logic.DTO;

namespace MarsRover.Logic
{
    public class World
    {
        private readonly int _width;
        private readonly int _height;
        private readonly List<Coordinate> _obstacles = new List<Coordinate>();
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

        public void SetObstacle(Coordinate obstacle)
        {
            _obstacles.Add(obstacle);
        }

        public List<Coordinate> GetObstacles()
        {
            return _obstacles;
        }

        public bool IsEmpty(Coordinate coordinate)
        {
            return !GetObstacles().Any(obstacles =>
                obstacles.GetXCoordinate() == coordinate.GetXCoordinate() &&
                obstacles.GetYCoordinate() == coordinate.GetYCoordinate());
        }
    }
}