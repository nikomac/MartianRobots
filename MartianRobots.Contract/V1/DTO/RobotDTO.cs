namespace MartianRobots.Contract.V1.DTO
{
    public class RobotDTO
    {
        public string InitialCoordinate { get; set; }
        public string LastKnownCoordinate { get; set; }
        public string CurrentCoordinate { get; set; }

        public string Instructions { get; set; }
        public bool IsLost { get; set; }

    }
}
