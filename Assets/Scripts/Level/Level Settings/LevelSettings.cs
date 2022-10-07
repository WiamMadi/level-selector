using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "ScriptableObjects/Level Settings")]
public class LevelSettings : Configuration<LevelSettingsData>
{
    [Header("JSON File Name")]
    [SerializeField] private string _jsonFileName;

    [Header("Level Settings")]
    public LevelSettingsData settings;

    private void OnEnable()
    {
        // Initialize LevelManager
        Init(_jsonFileName);

        // Load in level settings
        settings = Load() ?? new LevelSettingsData(1, 5, true);
    }

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
}
