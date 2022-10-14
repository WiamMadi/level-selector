using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSaveData
{
    public string id;
    public Scene scene;
    public LevelState state;

    public LevelSaveData(string id, Scene scence, LevelState state)
    {
        this.id = id;
        this.scene = scence;
        this.state = state;
    }
}
