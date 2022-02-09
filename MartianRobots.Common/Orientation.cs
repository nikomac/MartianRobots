using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MartianRobots.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Orientation
    {
        N,
        E,
        S,
        W
    }
}
