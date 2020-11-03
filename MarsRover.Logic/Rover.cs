using System.Collections.Generic;

namespace MarsRover.Logic
{
    public class Rover
    {
        private readonly Location _location;

        private readonly List<char> _turnRightOrder = new List<char>()
            {DirectionEnum.North, DirectionEnum.East, DirectionEnum.South, DirectionEnum.West};
        public Rover(Location location)
        {
            _location = location;
        }

        public Location GetLocation()
        {
            return _location;
        }

        public void MoveForward()
        {
            var currentDirection = _location.GetDirection();
            switch (currentDirection)
            {
                case DirectionEnum.South:
                    GoUp();
                    break;
                case DirectionEnum.North:
                    GoDown();
                    break;
                case DirectionEnum.East:
                    GoRight();
                    break;
                default:
                    GoLeft();
                    break;
            }
        }
        
        public void MoveBackward()
        {
            var currentDirection = _location.GetDirection();
            switch (currentDirection)
            {
                case DirectionEnum.North:
                    GoUp();
                    break;
                case DirectionEnum.East:
                    GoLeft();
                    break;
                case DirectionEnum.West:
                    GoRight();
                    break;
                default:
                    GoDown();
                    break;
            }
        }
        
        public void TurnRight()
        {
            var currentDirection = _location.GetDirection();
            var currentDirectionIndex = _turnRightOrder.IndexOf(currentDirection);
            var newDirection = currentDirectionIndex < _turnRightOrder.Count - 1
                ? _turnRightOrder[currentDirectionIndex + 1]
                : _turnRightOrder[0];
            _location.SetDirection(newDirection);
        }
        
        public void TurnLeft()
        {
            var currentDirection = _location.GetDirection();
            var currentDirectionIndex = _turnRightOrder.IndexOf(currentDirection);
            var newDirection = currentDirectionIndex == 0
                ? _turnRightOrder[^1]
                : _turnRightOrder[currentDirectionIndex - 1];
            _location.SetDirection(newDirection);
        }
        
        private void GoUp()
        {
            _location.SetYCoordinate(_location.GetYCoordinate() + 1);
        }

        private void GoDown()
        {
            _location.SetYCoordinate(_location.GetYCoordinate() - 1);
        }

        private void GoLeft()
        {
            _location.SetXCoordinate(_location.GetXCoordinate() - 1);
        }

        private void GoRight()
        {
            _location.SetXCoordinate(_location.GetXCoordinate() + 1);
        }
    }
}