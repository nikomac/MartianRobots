using MartianRobots.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace MartianRobots.Repositories.Context
{
    public class MartianRobotsDbContext : DbContext
    {
        public MartianRobotsDbContext(DbContextOptions<MartianRobotsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.RobotContext();
            modelBuilder.MissionContext();
            modelBuilder.GridContext();

        }

        public DbSet<Robot> Robots { get; set; }
        public DbSet<Grid> Grids { get; set; }
        public DbSet<Mission> Missions { get; set; }

    }
}
