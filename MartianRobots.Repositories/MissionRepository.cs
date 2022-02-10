using MartianRobots.Common.Entities;
using MartianRobots.Common.Exceptions;
using MartianRobots.Repositories.Context;
using MartianRobots.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MartianRobots.Repositories
{
    public class MissionRepository : IMissionRepository
    {
        private readonly MartianRobotsDbContext dbContext;

        public MissionRepository(MartianRobotsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Mission> Get(Guid id)
        {
            return await dbContext.Missions.Include(m => m.Robots).Include(m => m.Grid).AsNoTracking()
                .FirstOrDefaultAsync(r => r.ID == id) ?? throw new NotFoundException();
        }

        public async Task<List<Mission>> GetAll()
        {
            return await dbContext.Missions.Include(m => m.Robots).Include(m => m.Grid).AsNoTracking()
                .OrderBy(m => m.Date).ToListAsync();
        }

        public async Task<Mission> Insert(Mission mission)
        {
            await dbContext.Missions.AddAsync(mission);
            await dbContext.SaveChangesAsync();

            return mission;
        }

        public async Task<Mission> Update(Mission mission)
        {
            dbContext.Missions.Update(mission);
            await dbContext.SaveChangesAsync();

            return mission;
        }

        public async Task<int> Delete(Guid id)
        {
            var mission = await dbContext.Missions.Include(m => m.Robots).Include(m => m.Grid).AsNoTracking()
                .FirstOrDefaultAsync(r => r.ID == id);
            if (mission != null)
            {
                dbContext.Missions.Remove(mission);
                return await dbContext.SaveChangesAsync();
            }
            return 0;
        }

    }
}
