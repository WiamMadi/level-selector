using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelSaveData
{
    public string id;
    public Scence scence;
    public LevelState state;

    public LevelSaveData(string id, Scence scence, LevelState state)
    {
        this.id = id;
        this.scence = scence;
        this.state = state;
    }
}
