using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[JsonConverter(typeof(StringEnumConverter))]
public enum Scence
{
    LEVEL_0,
    LEVEL_1,
    LEVEL_2,
    LEVEL_3
}