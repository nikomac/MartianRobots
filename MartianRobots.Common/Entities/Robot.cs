using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace MartianRobots.Common.Entities
{
    public class Robot
    {
        public Guid ID { get; set; }
        public int Index { get; set; }
        public Coordinate InitialCoordinate { get; set; }
        public Coordinate LastKnownCoordinate { get; set; }
        public Coordinate CurrentCoordinate { get; set; }

        public List<Instruction> Instructions { get; set; }
        public bool IsLost { get; set; }

        public Guid MissionID { get; set; }

        public void Setup()
        {
            CurrentCoordinate = new Coordinate(InitialCoordinate.X, InitialCoordinate.Y, InitialCoordinate.Orientation);
            LastKnownCoordinate = new Coordinate(InitialCoordinate.X, InitialCoordinate.Y, InitialCoordinate.Orientation);
        }

        public void Restart()
        {
            ID = Guid.Empty;
            MissionID = Guid.Empty;
            Setup();
            IsLost = false;
        }

        public void SavePosition()
        {
            LastKnownCoordinate = new Coordinate(CurrentCoordinate.X, CurrentCoordinate.Y, CurrentCoordinate.Orientation);
        }

        public void TurnLeft()
        {
            var pos = ((int)CurrentCoordinate.Orientation);
            var orientations = Enum.GetValues<Orientation>();
            var newPos = pos == 0 ? orientations.Length - 1 : pos - 1;
            CurrentCoordinate.Orientation = orientations[newPos];
        }

        public void TurnRight()
        {
            var pos = ((int)CurrentCoordinate.Orientation);
            var orientations = Enum.GetValues<Orientation>();
            var newPos = (pos + 1) % orientations.Length;
            CurrentCoordinate.Orientation = orientations[newPos];
        }

        public void GoForward()
        {
            switch (CurrentCoordinate.Orientation)
            {
                case Orientation.N:
                    CurrentCoordinate.Y += 1;
                    break;
                case Orientation.E:
                    CurrentCoordinate.X += 1;
                    break;
                case Orientation.S:
                    CurrentCoordinate.Y -= 1;
                    break;
                case Orientation.W:
                    CurrentCoordinate.X -= 1;
                    break;
            };
        }

        public bool CheckInScent(List<Coordinate> scent)
        {
            return scent.Contains(CurrentCoordinate);
        }

        public void VerifyPosition(int maxX, int maxY)
        {
            IsLost = CurrentCoordinate.X > maxX || CurrentCoordinate.X < 0 || CurrentCoordinate.Y > maxY || CurrentCoordinate.X < 0;
        }


    }
}
