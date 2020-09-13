using System;

namespace RoverBot.Vehicles
{
    public class Roverbot : Vehicle
    {
        public Roverbot(int[] areaBoundaries) : base(areaBoundaries)
        {
        }

        public override void Move(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        MoveForward();
                        break;
                    case 'L':
                        ToLeft();
                        break;
                    case 'R':
                        ToRight();
                        break;
                    default:
                        throw new Exception($"Invalid command! Command: {command}");
                }
            }

            CheckAreaBoundaries();
        }
    }
}
