using MartianRobots.Common;
using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Services
{
    public class MissionService : IMissionService
    {
        private IMissionRepository missionRepository;

        public MissionService(IMissionRepository missionRepository)
        {
            this.missionRepository = missionRepository;
        }

        public async Task<List<Mission>> GetPastMissions()
        {
            return await missionRepository.GetAll();
        }


        public async Task<Mission> RunMission(Mission mission)
        {
            var savedMission = await missionRepository.Insert(mission);
            savedMission.RunMission();
            var updatedMission = await missionRepository.Update(savedMission);

            return updatedMission;
        }

        public async Task<Mission> ReRunMission(Guid id)
        {
            var pastMission = await missionRepository.Get(id);
            pastMission.Restart();
            return await RunMission(pastMission);
        }

    }
}
