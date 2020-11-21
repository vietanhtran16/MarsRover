using System;
using System.Collections.Generic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;
using MarsRover.Logic.Interfaces;

namespace MarsRover.Logic
{
    public class Rover: IRover
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
                { DirectionEnum.North, NextMoveUp },
                { DirectionEnum.South, NexMoveDown },
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
                { DirectionEnum.North, NexMoveDown },
                { DirectionEnum.South, NextMoveUp },
                { DirectionEnum.East, NextMoveLeft },
                { DirectionEnum.West, NextMoveRight }
            };
            var currentDirection = GetDirection();
            var newCoordinate = moveBackwardManual[currentDirection]();
            TryToMove(newCoordinate);
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
        
        private Coordinate NexMoveDown()
        {
            var newYCoordinate = _coordinate.GetYCoordinate() + 1;
            return new Coordinate(_coordinate.GetXCoordinate(), newYCoordinate > _world.GetHeight() ? 1 : newYCoordinate);
        }

        private Coordinate NextMoveUp()
        {
            var newYCoordinate = _coordinate.GetYCoordinate() - 1;
            return new Coordinate(_coordinate.GetXCoordinate(), newYCoordinate < 1 ? _world.GetHeight() : newYCoordinate);
        }

        private Coordinate NextMoveLeft()
        {
            var newXCoordinate = _coordinate.GetXCoordinate() - 1;
            return new Coordinate(newXCoordinate < 1 ? _world.GetWidth() : newXCoordinate, _coordinate.GetYCoordinate());
        }

        private Coordinate NextMoveRight()
        {
            var newXCoordinate = _coordinate.GetXCoordinate() + 1;
            return new Coordinate(newXCoordinate > _world.GetWidth() ? 1 : newXCoordinate, _coordinate.GetYCoordinate());
        }
        
        private void SetDirection(char newDirection)
        {
            _direction = newDirection;
        }
        
        private void SetCoordinate(Coordinate coordinate)
        {
            _coordinate = coordinate;
        }
    }
}