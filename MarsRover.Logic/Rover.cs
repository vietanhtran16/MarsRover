namespace MarsRover.Logic
{
    public class Rover
    {
        private readonly Location _location;
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
                    _location.SetYCoordinate(_location.GetYCoordinate() + 1);
                    break;
                case DirectionEnum.North:
                    _location.SetYCoordinate(_location.GetYCoordinate() -1);
                    break;
                case DirectionEnum.East:
                    _location.SetXCoordinate(_location.GetXCoordinate() + 1);
                    break;
                default:
                    _location.SetXCoordinate(_location.GetXCoordinate() -1);
                    break;
            }
        }

        public void MoveBackward()
        {
            throw new System.NotImplementedException();
        }
    }
}