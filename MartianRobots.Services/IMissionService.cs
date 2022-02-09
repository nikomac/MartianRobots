using MartianRobots.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots.Services
{
    public interface IMissionService
    {
        public Task<Mission> RunMission(Mission mission);
        public Task<Mission> ReRunMission(Guid mission);
        public Task<List<Mission>> GetPastMissions();
    }
}
