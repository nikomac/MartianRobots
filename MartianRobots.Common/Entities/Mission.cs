using System;
using System.Collections.Generic;
using System.Linq;

namespace MartianRobots.Common.Entities
{
    public class Mission
    {
        public Guid ID { get; set; }
        public List<Coordinate> Scent { get; set; } = new List<Coordinate>();

        public Grid Grid { get; set; }
        public List<Robot> Robots { get; set; }


        public void Restart()
        {
            ID = Guid.Empty;
            Scent = new List<Coordinate>();
            Robots.ForEach(r => r.Restart());
            Grid.Restart();
        }

        public void RunMission()
        {
            Robots.OrderBy(r => r.Index).ToList().ForEach(robot => {

                robot.Setup();

                foreach (Instruction instruction in robot.Instructions)
                {
                    switch (instruction)
                    {
                        case Instruction.L:
                            robot.TurnLeft();
                            break;
                        case Instruction.R:
                            robot.TurnRight();
                            break;
                        case Instruction.F:
                            if (robot.CheckInScent(Scent)) continue;
                            robot.GoForward();
                            break;
                    }
                    robot.VerifyPosition(Grid.MaxX, Grid.MaxY);
                    if (robot.IsLost)
                    {
                        Scent.Add(robot.CurrentCoordinate);
                        break;
                    }
                    robot.SavePosition();

                }
            });
        }

    }
}
