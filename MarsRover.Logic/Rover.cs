using System;
using System.Collections.Generic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;

namespace MarsRover.Logic
{
    public class Rover
    {
        private Coordinate _coordinate;
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
            var moveForwardManual = new Dictionary<char, Action>()
            {
                { DirectionEnum.North, GoDown },
                { DirectionEnum.South, GoUp },
                { DirectionEnum.East, GoRight },
                { DirectionEnum.West, GoLeft }
            };
            var currentDirection = GetDirection();
            moveForwardManual[currentDirection]();
        }
        
        public void MoveBackward()
        {
            var moveBackwardManual = new Dictionary<char, Action>()
            {
                { DirectionEnum.North, GoUp },
                { DirectionEnum.South, GoDown },
                { DirectionEnum.East, GoLeft },
                { DirectionEnum.West, GoRight }
            };
            var currentDirection = GetDirection();
            moveBackwardManual[currentDirection]();
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
            var newCoordinate = new Coordinate(_coordinate.GetXCoordinate(), _coordinate.GetYCoordinate() + 1);
            SetCoordinate(newCoordinate);
        }

        private void GoDown()
        {
            var newCoordinate = new Coordinate(_coordinate.GetXCoordinate(), _coordinate.GetYCoordinate() - 1);
            SetCoordinate(newCoordinate);
        }

        private void GoLeft()
        {
            var newCoordinate = new Coordinate(_coordinate.GetXCoordinate() - 1, _coordinate.GetYCoordinate());
            SetCoordinate(newCoordinate);
        }

        private void GoRight()
        {
            var newCoordinate = new Coordinate(_coordinate.GetXCoordinate() + 1, _coordinate.GetYCoordinate());
            SetCoordinate(newCoordinate);
        }
        
        private void SetCoordinate(Coordinate coordinate)
        {
            _coordinate = coordinate;
        }
    }
}