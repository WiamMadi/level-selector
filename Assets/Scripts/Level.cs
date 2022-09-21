using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class Level
{
    public string name;
    public Scence scence;
    public LevelState state;

    public Level(string name, Scence scence, LevelState state)
    {
        this.name = name;
        this.scence = scence;
        this.state = state;
    }
}

[JsonConverter(typeof(StringEnumConverter))]
public enum LevelState
{
    LOCKED,
    IN_PROGRESS,
    COMPLETED
}

[JsonConverter(typeof(StringEnumConverter))]
public enum Scence
{
    LEVEL_0,
    LEVEL_1,
    LEVEL_2,
    LEVEL_3
}