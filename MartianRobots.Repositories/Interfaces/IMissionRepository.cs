using MartianRobots.Common.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories.Interfaces
{
    public interface IMissionRepository
    {
        public Task<Mission> Get(Guid id);
        public Task<List<Mission>> GetAll();
        public Task<Mission> Insert(Mission mission);
        public Task<Mission> Update(Mission mission);
        public Task<int> Delete(Guid id);

    }
}
