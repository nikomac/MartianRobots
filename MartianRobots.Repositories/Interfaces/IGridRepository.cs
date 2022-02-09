using MartianRobots.Common.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories.Interfaces
{
    public interface IGridRepository
    {
        public Task<List<Grid>> GetAll();

    }
}
