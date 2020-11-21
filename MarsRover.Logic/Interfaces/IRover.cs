using MarsRover.Logic.DTO;

namespace MarsRover.Logic.Interfaces
{
    public interface IRover
    {
        Coordinate GetCoordinate();
        char GetDirection();
        void MoveForward();
        void MoveBackward();
        void TurnRight();
        void TurnLeft();
    }
}