using MartianRobots.Common;
using MartianRobots.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Api.Translators
{
    public static class MissionTranslator
    {

        public static Mission TranslateInput(string input)
        {
            var missionInput = input.Split('\n');

            return new Mission
            {
                Grid = TranslateGridInput(missionInput.ElementAtOrDefault(0)),
                Robots = TranslateRobotInput(missionInput.Skip(1)),
            };
        }

        private static Grid TranslateGridInput(string input)
        {
            var gridParams = input.Split(' ');
            var gridX = int.Parse(gridParams.ElementAtOrDefault(0));
            var gridY = int.Parse(gridParams.ElementAtOrDefault(1));
            return new Grid
            {
                MaxX = gridX,
                MaxY = gridY,
            };
        }

        private static List<Robot> TranslateRobotInput(IEnumerable<string> input)
        {
            return Enumerable.Range(0, input.Count() / 2).Select(i =>
            {
                var robotInput = input.Skip(i * 2).Take(2);
                var robotCoordinates = robotInput.ElementAt(0).Trim().Split(' ');
                var robotX = int.Parse(robotCoordinates.ElementAtOrDefault(0));
                var robotY = int.Parse(robotCoordinates.ElementAtOrDefault(1));
                var robotO = Enum.Parse<Orientation>(robotCoordinates.ElementAtOrDefault(2));
                var robotI = robotInput.ElementAt(1).Trim().Select(ins => Enum.Parse<Instruction>(ins.ToString()));
                return new Robot
                {
                    Index = i,
                    InitialCoordinate = new Coordinate(robotX, robotY, robotO),
                    Instructions = robotI.ToList(),
                };
            }).ToList();
        }


        public static string TranslateOutput(Mission mission)
        {
            return string.Join("\n", mission.Robots.Select(robot =>
                $"{robot.LastKnownCoordinate.X} {robot.LastKnownCoordinate.Y} {robot.LastKnownCoordinate.Orientation}{(robot.IsLost ? " LOST" : "")}"
            ));
        }
    }
}
