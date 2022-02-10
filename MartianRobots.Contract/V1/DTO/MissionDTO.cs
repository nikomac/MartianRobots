using System;
using System.Collections.Generic;

namespace MartianRobots.Contract.V1.DTO
{
    public class MissionDTO
    {
        public Guid ID { get; set; }
        public DateTime Date { get; set; }
        public List<string> Scent { get; set; }
        public GridDTO Grid { get; set; }
        public List<RobotDTO> Robots { get; set; }       

    }
}
