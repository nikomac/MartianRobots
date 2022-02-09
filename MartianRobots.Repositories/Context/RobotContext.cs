using MartianRobots.Common;
using MartianRobots.Common.Entities;
using MartianRobots.Repositories.Helper;
using Microsoft.EntityFrameworkCore;

namespace MartianRobots.Repositories.Context
{

    public static class RobotContextExtension
    {
        public static void RobotContext(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Robot>()
                 .Property(e => e.Instructions)
                 .HasConversion(
                     v => ListHelper.Serialize(v),
                     v => ListHelper.Deserialize<Instruction>(v)
                 )
                 .Metadata.SetValueComparer(ListHelper.Comparer<Instruction>());

            modelBuilder.Entity<Robot>()
               .Property(e => e.InitialCoordinate)
               .HasConversion(
                   v => v.ToString(),
                   v => Coordinate.ToCoordinate(v)
               );

            modelBuilder.Entity<Robot>()
               .Property(e => e.LastKnownCoordinate)
               .HasConversion(
                   v => v.ToString(),
                   v => Coordinate.ToCoordinate(v)
               );

            modelBuilder.Entity<Robot>()
               .Property(e => e.CurrentCoordinate)
               .HasConversion(
                   v => v.ToString(),
                   v => Coordinate.ToCoordinate(v)
               );


        }
    }

}
