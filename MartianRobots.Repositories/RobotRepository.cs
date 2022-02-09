using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Context;
using MartianRobots.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MartianRobots.Repositories
{
    public class RobotRepository : IRobotRepository
    {
        private readonly MartianRobotsDbContext dbContext;

        public RobotRepository(MartianRobotsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Robot>> GetAll()
        {
            return await dbContext.Robots.AsNoTracking().ToListAsync();
        }

    }
}
