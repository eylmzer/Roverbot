using RoverBot.Vehicles;
using System;
using System.Linq;

namespace RoverBot
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please insert area bondaries (X,Y): ");
                var areaBoundaries = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var roverbot = new Roverbot(areaBoundaries);

                Console.WriteLine("Please insert vehicle position (X,Y,P): ");
                var startPosition = Console.ReadLine().Split(' ');

                roverbot.X = int.Parse(startPosition[0]);
                roverbot.Y = int.Parse(startPosition[1]);
                roverbot.Direction = (Direction)Enum.Parse(typeof(Direction), startPosition[2]);

                Console.WriteLine("Please insert direction commands ");
                var commands = Console.ReadLine().ToUpper();

                roverbot.Move(commands);

                Console.WriteLine($"Roverbot current position => X: {roverbot.X}, Y:{roverbot.Y}, Direction: {roverbot.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured. Exception: {ex.Message}");
            }

            Console.Read();
        }
    }
}
