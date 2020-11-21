using System;
using System.Collections.Generic;
using MarsRover.Logic.DTO;
using MarsRover.Logic.Enums;
using MarsRover.Logic.Interfaces;

namespace MarsRover.Logic
{
    public class Driver
    {
        private readonly IRover _rover;
        public Driver(IRover rover)
        {
            _rover = rover;
        }
        
        public void IssueCommands(string commands)
        {
            foreach (var command in commands)
            {
                IssueCommand(command);
            }
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