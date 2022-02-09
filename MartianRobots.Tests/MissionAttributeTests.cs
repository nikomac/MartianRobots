using MartianRobots.Api.Validators;
using MartianRobots.Tests.Common;
using NUnit.Framework;
using System.Linq;

namespace MartianRobots.Tests
{
    public class MissionAttributeTests
    {



        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void ValidateGridTest()
        {
            var attribute = new MissionStringAttribute();

            var validInput = "5 3";
            var errors = attribute.ValidateGrid(validInput);
            Assert.IsFalse(errors.Any());

            var invalidInput0 = "";
            errors = attribute.ValidateGrid(invalidInput0);
            Assert.IsTrue(errors.Any());

            var invalidInput1 = "3 55";
            errors = attribute.ValidateGrid(invalidInput1);
            Assert.IsTrue(errors.Any());

            var invalidInput2 = "-1 3";
            errors = attribute.ValidateGrid(invalidInput2);
            Assert.IsTrue(errors.Any());

            var invalidInput3 = "0";
            errors = attribute.ValidateGrid(invalidInput3);
            Assert.IsTrue(errors.Any());
        }


        [Test]
        public void ValidateRobotsTest()
        {
            var attribute = new MissionStringAttribute();

            var validInput0 = "1 1 E\nRFRFRFRF".Split("\n");
            var errors = attribute.ValidateRobots(validInput0);
            Assert.IsFalse(errors.Any());

            var validInput1 = "1 1 E\n".Split("\n");
            errors = attribute.ValidateRobots(validInput1);
            Assert.IsFalse(errors.Any());

            var invalidInput0 = "1 1 E".Split("\n");
            errors = attribute.ValidateRobots(invalidInput0);
            Assert.IsTrue(errors.Any());

            var invalidInput1 = "51 1 S\nFRRF".Split("\n");
            errors = attribute.ValidateRobots(invalidInput1);
            Assert.IsTrue(errors.Any());

            var invalidInput2 = "-1 1 Q\nFRRF".Split("\n");
            errors = attribute.ValidateRobots(invalidInput2);
            Assert.IsTrue(errors.Any());

            var invalidInput3 = $"1 1 E\n{Enumerable.Range(0, 100).Select(i => "F")}".Split("\n");
            errors = attribute.ValidateRobots(invalidInput3);
            Assert.IsTrue(errors.Any());
        }



    }
}