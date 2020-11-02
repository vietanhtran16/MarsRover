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
                    _location.SetXCoordinate(_location.GetXCoordinate() + 1);
                    break;
                case DirectionEnum.North:
                    _location.SetXCoordinate(_location.GetXCoordinate() -1);
                    break;
                case DirectionEnum.East:
                    _location.SetYCoordinate(_location.GetYCoordinate() + 1);
                    break;
                default:
                    _location.SetYCoordinate(_location.GetYCoordinate() -1);
                    break;
            }
        }
    }
}