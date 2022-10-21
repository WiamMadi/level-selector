using UnityEngine;

public class SaveObjs : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private LevelSettings levelSettings;

    // Save levels and level settings when application is paused
    void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            levelManager.SaveLevels();
            levelSettings.SaveSettings();
        }
    }
}
