using MartianRobots.Common;
using MartianRobots.Common.Entities;
using NUnit.Framework;
using System.Collections.Generic;

namespace MartianRobots.Tests
{
    public class RobotTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TurnTest()
        {

            var robot = new Robot() { CurrentCoordinate = new Coordinate(0, 0, Orientation.N) };
            Assert.AreEqual(Orientation.N, robot.CurrentCoordinate.Orientation);
            robot.TurnRight();
            Assert.AreEqual(Orientation.E, robot.CurrentCoordinate.Orientation);
            robot.TurnRight();
            Assert.AreEqual(Orientation.S, robot.CurrentCoordinate.Orientation);
            robot.TurnRight();
            Assert.AreEqual(Orientation.W, robot.CurrentCoordinate.Orientation);
            robot.TurnRight();
            Assert.AreEqual(Orientation.N, robot.CurrentCoordinate.Orientation);
            robot.TurnLeft();
            Assert.AreEqual(Orientation.W, robot.CurrentCoordinate.Orientation);
            robot.TurnLeft();
            Assert.AreEqual(Orientation.S, robot.CurrentCoordinate.Orientation);
            robot.TurnLeft();
            Assert.AreEqual(Orientation.E, robot.CurrentCoordinate.Orientation);
            robot.TurnLeft();
            Assert.AreEqual(Orientation.N, robot.CurrentCoordinate.Orientation);
        }


        [Test]
        public void ForwardTest()
        {

            var robot = new Robot();
            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.N);
            robot.GoForward();
            Assert.AreEqual(robot.CurrentCoordinate, new Coordinate(0, 1, Orientation.N));

            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.E);
            robot.GoForward();
            Assert.AreEqual(robot.CurrentCoordinate, new Coordinate(1, 0, Orientation.E));

            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.S);
            robot.GoForward();
            Assert.AreEqual(robot.CurrentCoordinate, new Coordinate(0, -1, Orientation.S));

            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.W);
            robot.GoForward();
            Assert.AreEqual(robot.CurrentCoordinate, new Coordinate(-1, 0, Orientation.W));

        }


        [Test]
        public void CheckInScentTest()
        {
            var scent = new List<Coordinate> { new Coordinate(1, 1, Orientation.N) };
            var robot = new Robot();

            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.N);
            Assert.IsFalse(robot.CheckInScent(scent));

            robot.CurrentCoordinate = new Coordinate(1, 1, Orientation.N);
            Assert.IsTrue(robot.CheckInScent(scent));
        }


        [Test]
        public void IsLostTest()
        {
            var robot = new Robot();

            robot.CurrentCoordinate = new Coordinate(0, 0, Orientation.N);
            robot.VerifyPosition(2, 2);
            Assert.IsFalse(robot.IsLost);

            robot.CurrentCoordinate = new Coordinate(1, 1, Orientation.N);
            robot.VerifyPosition(2, 2);
            Assert.IsFalse(robot.IsLost);

            robot.CurrentCoordinate = new Coordinate(2, 2, Orientation.N);
            robot.VerifyPosition(2, 2);
            Assert.IsFalse(robot.IsLost);

            robot.CurrentCoordinate = new Coordinate(3, 1, Orientation.N);
            robot.VerifyPosition(2, 2);
            Assert.IsTrue(robot.IsLost);

            robot.CurrentCoordinate = new Coordinate(-1, 1, Orientation.N);
            robot.VerifyPosition(2, 2);
            Assert.IsTrue(robot.IsLost);

        }


    }
}