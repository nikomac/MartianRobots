using System;
using System.Text.Json.Serialization;

namespace MartianRobots.Common
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Orientation Orientation { get; set; }

        public Coordinate(int x, int y, Orientation orientation)
        {
            X = x;
            Y = y;
            Orientation = orientation;
        }

        public override string ToString()
        {
            return string.Join(' ', X, Y, Orientation);
        }

        public override bool Equals(object obj)
        {
            var c = obj as Coordinate;
            return c.X == X && c.Y == Y && c.Orientation == Orientation;
        }

        public static Coordinate ToCoordinate(string value)
        {
            try
            {
                var array = value.Trim().Split(' ');
                var x = int.Parse(array[0]);
                var y = int.Parse(array[1]);
                var o = Enum.Parse<Orientation>(array[2]);
                return new Coordinate(x, y, o);
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
