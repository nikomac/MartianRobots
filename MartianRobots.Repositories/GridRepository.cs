using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Context;
using MartianRobots.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories
{
    public class GridRepository : IGridRepository
    {
        private readonly MartianRobotsDbContext dbContext;

        public GridRepository(MartianRobotsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Grid>> GetAll()
        {
            return await dbContext.Grids.AsNoTracking().ToListAsync();
        }

    }
}