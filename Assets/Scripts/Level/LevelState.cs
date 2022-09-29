using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum LevelState
{
    LOCKED,
    IN_PROGRESS,
    COMPLETED
}