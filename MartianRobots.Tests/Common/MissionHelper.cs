using MartianRobots.Common;
using MartianRobots.Common.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace MartianRobots.Tests.Common
{
    public static class MissionHelper
    {

        public static Mission CreateMission()
        {
            var mission = new Mission
            {
                Grid = new Grid { MaxX = 5, MaxY = 3 },
                Robots = new List<Robot> {

                    new Robot { InitialCoordinate = new Coordinate(1, 1, Orientation.E), Instructions = new List<Instruction>{
                        Instruction.R,Instruction.F,Instruction.R,Instruction.F,Instruction.R,Instruction.F,Instruction.R,Instruction.F } },

                    new Robot { InitialCoordinate = new Coordinate(3, 2, Orientation.N), Instructions = new List<Instruction>{
                        Instruction.F,Instruction.R,Instruction.R,Instruction.F,Instruction.L,Instruction.L,Instruction.F,Instruction.F,
                        Instruction.R,Instruction.R,Instruction.F,Instruction.L,Instruction.L } },

                    new Robot { InitialCoordinate = new Coordinate(0, 3, Orientation.W), Instructions = new List<Instruction>{
                        Instruction.L,Instruction.L,Instruction.F,Instruction.F,Instruction.F,Instruction.R,Instruction.F,Instruction.L,
                        Instruction.F,Instruction.L } }
                }
            };

            return mission;
        }


        public static void CheckMissionResults(Mission mission)
        {
            var robot0 = mission.Robots[0];
            var robot1 = mission.Robots[1];
            var robot2 = mission.Robots[2];

            Assert.IsFalse(robot0.IsLost);
            Assert.IsTrue(robot1.IsLost);
            Assert.IsFalse(robot2.IsLost);

            Assert.AreEqual(new Coordinate(1, 1, Orientation.E), robot0.LastKnownCoordinate);
            Assert.AreEqual(new Coordinate(3, 3, Orientation.N), robot1.LastKnownCoordinate);
            Assert.AreEqual(new Coordinate(4, 2, Orientation.N), robot2.LastKnownCoordinate);
        }

    }
}
