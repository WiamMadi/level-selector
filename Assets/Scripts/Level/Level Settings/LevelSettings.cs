using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/Level Settings")]
public class LevelSettings : Configuration<LevelSettingsData>
{
    [Header("Level Settings")]
    public LevelSettingsData settings;

    private void OnEnable()
    {
        // Initialize LevelManager
        Init("levelSettings.json");

        // Load in level settings
        settings = Load() ?? new LevelSettingsData(1, 5, true);
    }

    // Save the level settings after they have been modified by the inspector
    private void OnValidate()
    {
        // Set current page back to 1, if the user does not want to save the page position
        if (settings.saveCurrentPagePosition == false)
        {
            settings.currentPage = 1;
        }

        // Save data
        Save(settings);
    }

    // Save the level settings into the file
    public void SaveSettings()
    {
        Save(settings);
    }
}
