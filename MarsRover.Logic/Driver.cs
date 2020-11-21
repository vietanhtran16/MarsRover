using System;
using System.Collections.Generic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;

namespace MarsRover.Logic
{
    public class Driver
    {
        private readonly Rover _rover;
        public Driver(Rover rover)
        {
            _rover = rover;
        }

        public void IssueCommand(char command)
        {
            var commandManual = new Dictionary<char, Action>()
            {
                { CommandEnum.Forward, _rover.MoveForward },
                { CommandEnum.Backward, _rover.MoveBackward },
                { CommandEnum.Right, _rover.TurnRight },
                { CommandEnum.Left, _rover.TurnLeft }
            };
            commandManual[command]();
        }
    }
}