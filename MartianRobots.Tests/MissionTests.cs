using MartianRobots.Tests.Common;
using NUnit.Framework;

namespace MartianRobots.Tests
{
    public class MissionTests
    {

        

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void RunMissionTest()
        {
            var mission = MissionHelper.CreateMission();

            mission.RunMission();

            MissionHelper.CheckMissionResults(mission);
        }



    }
}