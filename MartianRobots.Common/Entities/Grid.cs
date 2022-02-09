using System;

namespace MartianRobots.Common.Entities
{
    public class Grid
    {
        public Guid ID { get; set; }
        public int MaxX { get; set; }
        public int MaxY { get; set; }

        public Guid MissionID { get; set; }

        public void Restart()
        {
            ID = Guid.Empty;
            MissionID = Guid.Empty;
        }
    }
}
