using System.Text.Json.Serialization;

namespace MartianRobots.Common
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Instruction
    {
        L,
        R,
        F
    }
}
