using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "ScriptableObjects/Levels")]
public class LevelManager : Configuration<List<LevelSaveData>>
{
    [Header("JSON File Name")]
    [SerializeField] private string _jsonFileName;

    [Header("Saved Levels")]
    public List<LevelSaveData> levels;

    private void OnEnable()
    {
        // Initialize LevelManager
        Init(_jsonFileName);

        // Load in levels
        levels = Load() ?? new List<LevelSaveData>();
    }

    private void OnValidate()
    {
        // Save data
        Save(levels);
    }
}
