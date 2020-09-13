using FluentAssertions;
using RoverBot;
using System;
using System.Collections.Generic;
using Xunit;

namespace Roverbot.Test
{
    public class RoverBotTest
    {
        public RoverBotTest()
        {
        }


        [Theory]
        [MemberData(nameof(Data))]
        public void Should_RoverBotMovingAsExpected_When_SendValidCommands(int[] areaBoundaries, string[] startPosition, string commands, string[] expectedposition)
        {
            var roverBot = new RoverBot.Vehicles.Roverbot(areaBoundaries)
            {
                X = int.Parse(startPosition[0]),
                Y = int.Parse(startPosition[1]),
                Direction = (Direction)Enum.Parse(typeof(Direction), startPosition[2])
            };

            roverBot.Move(commands);

            roverBot.X.Should().Be(int.Parse(expectedposition[0]));
            roverBot.Y.Should().Be(int.Parse(expectedposition[1]));
            roverBot.Direction.Should().Be((Direction)Enum.Parse(typeof(Direction), expectedposition[2]));
        }

        [Theory]
        [InlineData(new object[] { new int[] { 5, 5 }, new string[] { "1", "2", "N" }, "LMLMPMALMM"})]
        public void Should_ThrowException_When_SendInvalidCommands(int[] areaBoundaries, string[] startPosition, string commands)
        {
            var roverBot = new RoverBot.Vehicles.Roverbot(areaBoundaries)
            {
                X = int.Parse(startPosition[0]),
                Y = int.Parse(startPosition[1]),
                Direction = (Direction)Enum.Parse(typeof(Direction), startPosition[2])
            };

            Action act = () => roverBot.Move(commands);

            act.Should().Throw<Exception>()
                .WithMessage("Invalid command! Command: P");
        }

        [Theory]
        [InlineData(new object[] { new int[] { 4, 4 }, new string[] { "3", "2", "N" }, "MRMMLMRMM" })]
        public void Should_ThrowException_When_RoverPositionIsOutOfDefinedBoundaries(int[] areaBoundaries, string[] startPosition, string commands)
        {
            var roverBot = new RoverBot.Vehicles.Roverbot(areaBoundaries)
            {
                X = int.Parse(startPosition[0]),
                Y = int.Parse(startPosition[1]),
                Direction = (Direction)Enum.Parse(typeof(Direction), startPosition[2])
            };

            Action act = () => roverBot.Move(commands);

            act.Should().Throw<Exception>()
                .WithMessage("The vehicle is out of defined boundaries. Vehicle points: (7, 4), Area Boundaries: (0,0) (4, 4)");
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
                new object[] { new int[] { 5, 5 }, new string[] { "1","2","N" }, "LMLMLMLMM", new string[] { "1", "3", "N" } },
                new object[] { new int[] { 5, 5 }, new string[] { "3","3","E" }, "MMRMMRMRRM", new string[] { "5", "1", "E" } },
                new object[] { new int[] { 8, 10 }, new string[] { "5","4","E" }, "LMMRMRM", new string[] { "6", "5", "S" } },
                new object[] { new int[] { 4, 4 }, new string[] { "2","1","W" }, "RMRM", new string[] { "3", "2", "E" }  },
        };

    }
}
