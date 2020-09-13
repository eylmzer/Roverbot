using System;

namespace RoverBot.Vehicles
{
    public abstract class Vehicle : IMoveable
    {
        public int X 
        { 
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        private int _x;
        private int _y;
        private Direction _direction;

        private readonly int[] _areaBoundaries;

        public Vehicle(int[] areaBoundaries)
        {
            _areaBoundaries = areaBoundaries;
        }

        public abstract void Move(string commands);

        protected void CheckAreaBoundaries()
        {
            if (_x < 0 || _x > _areaBoundaries[0] || _y < 0 || _y > _areaBoundaries[1])
                throw new Exception($"The vehicle is out of defined boundaries. Vehicle points: ({_x}, {_y}), Area Boundaries: (0,0) ({_areaBoundaries[0]}, {_areaBoundaries[1]})");
        }

        public void MoveForward()
        {
            switch (_direction)
            {
                case Direction.N:
                    _y += 1;
                    break;
                case Direction.S:
                    _y -= 1;
                    break;
                case Direction.E:
                    _x += 1;
                    break;
                case Direction.W:
                    _x -= 1;
                    break;
                default:
                    throw new Exception($"Invalid command! Command: {_direction}");
            }
        }

        public void ToLeft()
        {
            _direction = _direction switch
            {
                Direction.N => Direction.W,
                Direction.S => Direction.E,
                Direction.E => Direction.N,
                Direction.W => Direction.S,
                _ => throw new Exception($"Invalid command! Command: {_direction}")
            };
        }

        public void ToRight()
        {
            _direction = _direction switch
            {
                Direction.N => Direction.E,
                Direction.S => Direction.W,
                Direction.E => Direction.S,
                Direction.W => Direction.N,
                _ => throw new Exception($"Invalid command! Command: {_direction}")
            };
        }
    }
}
