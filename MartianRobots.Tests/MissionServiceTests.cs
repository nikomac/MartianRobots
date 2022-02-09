using MartianRobots.Common;
using MartianRobots.Common.Entities;
using MartianRobots.Repositories;
using MartianRobots.Repositories.Interfaces;
using MartianRobots.Repositories.Stubs;
using MartianRobots.Services;
using MartianRobots.Tests.Common;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Tests
{
    public class MissionServiceTests
    {

        private IMissionService missionService;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();

            services.AddTransient<IMissionRepository, MissionRepositoryStub>();
            services.AddTransient<IMissionService, MissionService>();
            var serviceProvider = services.BuildServiceProvider();

            missionService = serviceProvider.GetService<IMissionService>();
        }


        [Test]
        public async Task RunMissionTest()
        {
            var mission = MissionHelper.CreateMission();
            var runnedMission = await missionService.RunMission(mission);
            MissionHelper.CheckMissionResults(runnedMission);
        }


        [Test]
        public async Task ReRunMissionTest()
        {
            var runnedMission = await missionService.ReRunMission(new Guid());
            MissionHelper.CheckMissionResults(runnedMission);
        }        


        [Test]
        public async Task GetPastMissionsTest()
        {
            var missions = await missionService.GetPastMissions();
            Assert.AreEqual(3, missions.Count);
        }

    }
}