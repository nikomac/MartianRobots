using MartianRobots.Common.Entities;
using MartianRobots.Contract.V1.DTO;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Contract.V1.Translators
{
    public static class RobotTranslator
    {


        public static RobotDTO Translate(Robot robot)
        {
            return new RobotDTO
            {
                InitialCoordinate = robot.InitialCoordinate.ToString(),
                LastKnownCoordinate = robot.LastKnownCoordinate.ToString(),
                CurrentCoordinate = robot.CurrentCoordinate.ToString(),
                Instructions = string.Join("",robot.Instructions.Select(x => x.ToString())),
                IsLost = robot.IsLost,
            };
        }

        public static IEnumerable<RobotDTO> Translate(IEnumerable<Robot> robots)
        {
            return robots.Select(robot => Translate(robot));
        }

    }
}
