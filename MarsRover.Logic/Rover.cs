using System.Collections.Generic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;

namespace MarsRover.Logic
{
    public class Rover
    {
        private readonly Coordinate _coordinate;
        private char _direction;

        private readonly List<char> _turnRightOrder = new List<char>()
            {DirectionEnum.North, DirectionEnum.East, DirectionEnum.South, DirectionEnum.West};
        public Rover(Coordinate coordinate, char initialDirection)
        {
            _coordinate = coordinate;
            _direction = initialDirection;
        }

        public Coordinate GetCoordinate()
        {
            return _coordinate;
        }
        
        public char GetDirection()
        {
            return _direction;
        }

        public void MoveForward()
        {
            var currentDirection = GetDirection();
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
            var currentDirection = GetDirection();
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
            var currentDirection = GetDirection();
            var currentDirectionIndex = _turnRightOrder.IndexOf(currentDirection);
            var newDirection = currentDirectionIndex < _turnRightOrder.Count - 1
                ? _turnRightOrder[currentDirectionIndex + 1]
                : _turnRightOrder[0];
            SetDirection(newDirection);
        }
        
        public void TurnLeft()
        {
            var currentDirection = GetDirection();
            var currentDirectionIndex = _turnRightOrder.IndexOf(currentDirection);
            var newDirection = currentDirectionIndex == 0
                ? _turnRightOrder[^1]
                : _turnRightOrder[currentDirectionIndex - 1];
            SetDirection(newDirection);
        }
        
        private void SetDirection(char newDirection)
        {
            _direction = newDirection;
        }
        
        private void GoUp()
        {
            _coordinate.SetYCoordinate(_coordinate.GetYCoordinate() + 1);
        }

        private void GoDown()
        {
            _coordinate.SetYCoordinate(_coordinate.GetYCoordinate() - 1);
        }

        private void GoLeft()
        {
            _coordinate.SetXCoordinate(_coordinate.GetXCoordinate() - 1);
        }

        private void GoRight()
        {
            _coordinate.SetXCoordinate(_coordinate.GetXCoordinate() + 1);
        }
    }
}