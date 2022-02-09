using MartianRobots.Common;
using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Helper;
using Microsoft.EntityFrameworkCore;

namespace MartianRobots.Repositories.Context
{

    public static class MissionContextExtension
    {
        public static void MissionContext(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Mission>()
                 .Property(e => e.Scent)
                 .HasConversion(
                     v => ListHelper.Serialize(v),
                     v => ListHelper.Deserialize<Coordinate>(v)
                 )
                 .Metadata.SetValueComparer(ListHelper.Comparer<Coordinate>()); ;

        }
    }

}
