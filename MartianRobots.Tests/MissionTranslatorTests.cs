using MartianRobots.Api.Translators;
using MartianRobots.Common;
using MartianRobots.Tests.Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Tests
{
    public class MissionTranslatorTests
    {



        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void TranslateInputTest()
        {
            var mission = MissionTranslator.TranslateInput("5 3\n1 1 E\nRFRFRFRF\n3 2 N\nFRRFLLFFRRFLL\n0 3 W\nLLFFFRFLFL");
            Assert.AreEqual(5, mission.Grid.MaxX);
            Assert.AreEqual(3, mission.Grid.MaxY);

            Assert.AreEqual(3, mission.Robots.Count);
            var robot0 = mission.Robots[0];
            var robot1 = mission.Robots[1];
            var robot2 = mission.Robots[2];

            var r0i = new List<Instruction>
            {
                Instruction.R,
                Instruction.F,
                Instruction.R,
                Instruction.F,
                Instruction.R,
                Instruction.F,
                Instruction.R,
                Instruction.F,
            };

            var r1i = new List<Instruction>
            {
                Instruction.F,
                Instruction.R,
                Instruction.R,
                Instruction.F,
                Instruction.L,
                Instruction.L,
                Instruction.F,
                Instruction.F,
                Instruction.R,
                Instruction.R,
                Instruction.F,
                Instruction.L,
                Instruction.L,
            };

            var r2i = new List<Instruction>
            {
                Instruction.L,
                Instruction.L,
                Instruction.F,
                Instruction.F,
                Instruction.F,
                Instruction.R,
                Instruction.F,
                Instruction.L,
                Instruction.F,
                Instruction.L,
            };

            Assert.AreEqual(new Coordinate(1, 1, Orientation.E), robot0.InitialCoordinate);
            Assert.AreEqual(r0i.Count, robot0.Instructions.Count);
            Assert.IsTrue(r0i.SequenceEqual(robot0.Instructions));

            Assert.AreEqual(new Coordinate(3, 2, Orientation.N), robot1.InitialCoordinate);
            Assert.AreEqual(r1i.Count, robot1.Instructions.Count);
            Assert.IsTrue(r1i.SequenceEqual(robot1.Instructions));

            Assert.AreEqual(new Coordinate(0, 3, Orientation.W), robot2.InitialCoordinate);
            Assert.AreEqual(r2i.Count, robot2.Instructions.Count);
            Assert.IsTrue(r2i.SequenceEqual(robot2.Instructions));

        }

        [Test]
        public void TranslateOutputTest()
        {
            var mission = MissionHelper.CreateMission();

            var robot0 = mission.Robots[0];
            robot0.Setup();

            var robot1 = mission.Robots[1];
            robot1.Setup();
            robot1.IsLost = true;

            var robot2 = mission.Robots[2];
            robot2.Setup();
            robot2.IsLost = true;

            var output = MissionTranslator.TranslateOutput(mission);
            Assert.AreEqual("1 1 E\n3 2 N LOST\n0 3 W LOST", output);
        }

    }
}