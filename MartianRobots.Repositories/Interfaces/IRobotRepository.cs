using MartianRobots.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories.Interfaces
{
    public interface IRobotRepository
    {
        public Task<List<Robot>> GetAll();
    }
}
