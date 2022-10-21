using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class LevelManager : Configuration<List<LevelSaveData>>
{
    [Header("Saved Levels")]
    public List<LevelSaveData> levels;

    private void OnEnable()
    {
        // Initialize LevelManager
        Init("levels.json");

        // Load in levels
        levels = Load() ?? new List<LevelSaveData>();
    }

    // Save the levels after they have been modified by the inspector
    private void OnValidate()
    {
        Save(levels);
    }

    // Save the levels into the file
    public void SaveLevels()
    {
        Save(levels);
    }
}
