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
        private readonly World _world;

        private readonly List<char> _turnRightOrder = new List<char>()
            {DirectionEnum.North, DirectionEnum.East, DirectionEnum.South, DirectionEnum.West};
        public Rover(Coordinate coordinate, char initialDirection, World world)
        {
            _coordinate = coordinate;
            _direction = initialDirection;
            _world = world;
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
            var moveForwardManual = new Dictionary<char, Func<Coordinate>>()
            {
                { DirectionEnum.North, NextMoveDown },
                { DirectionEnum.South, NexMoveUp },
                { DirectionEnum.East, NextMoveRight },
                { DirectionEnum.West, NextMoveLeft }
            };
            var currentDirection = GetDirection();
            var newCoordinate = moveForwardManual[currentDirection]();
            TryToMove(newCoordinate);
        }

        public void MoveBackward()
        {
            var moveBackwardManual = new Dictionary<char, Func<Coordinate>>()
            {
                { DirectionEnum.North, NexMoveUp },
                { DirectionEnum.South, NextMoveDown },
                { DirectionEnum.East, NextMoveLeft },
                { DirectionEnum.West, NextMoveRight }
            };
            var currentDirection = GetDirection();
            var newCoordinate = moveBackwardManual[currentDirection]();
            TryToMove(newCoordinate);
        }
        
        private void TryToMove(Coordinate coordinate)
        {
            if (_world.IsEmpty(coordinate))
            {
                SetCoordinate(coordinate);
            }
            else
            {
                throw new Exception($"Bump into obstacle at {coordinate.GetXCoordinate()},{coordinate.GetYCoordinate()}");
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
        
        private Coordinate NexMoveUp()
        {
            return new Coordinate(_coordinate.GetXCoordinate(), _coordinate.GetYCoordinate() + 1);
        }

        private Coordinate NextMoveDown()
        {
            return new Coordinate(_coordinate.GetXCoordinate(), _coordinate.GetYCoordinate() - 1);
        }

        private Coordinate NextMoveLeft()
        {
            return new Coordinate(_coordinate.GetXCoordinate() - 1, _coordinate.GetYCoordinate());
        }

        private Coordinate NextMoveRight()
        {
            return new Coordinate(_coordinate.GetXCoordinate() + 1, _coordinate.GetYCoordinate());
        }
        
        private void SetCoordinate(Coordinate coordinate)
        {
            _coordinate = coordinate;
        }
    }
}