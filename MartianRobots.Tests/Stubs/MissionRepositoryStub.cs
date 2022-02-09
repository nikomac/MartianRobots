using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Interfaces;
using MartianRobots.Tests.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories.Stubs
{
    public class MissionRepositoryStub : IMissionRepository
    {


        public Task<Mission> Get(Guid id)
        {
            var mission = MissionHelper.CreateMission();
            return Task.FromResult(mission);
        }

        public Task<List<Mission>> GetAll()
        {
            return Task.FromResult(new List<Mission> { MissionHelper.CreateMission(), MissionHelper.CreateMission(), MissionHelper.CreateMission() });
        }

        public Task<Mission> Insert(Mission mission)
        {
            return Task.FromResult(mission);
        }

        public Task<Mission> Update(Mission mission)
        {
            return Task.FromResult(mission);
        }

        public Task<int> Delete(Guid id)
        {
            return Task.FromResult(1);
        }

    }
}
