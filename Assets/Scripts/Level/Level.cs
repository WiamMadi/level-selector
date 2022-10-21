using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public string id;
    [SerializeField] public Scene scene;
    [SerializeField] public LevelState state;

    private void Start()
    {
        text.text = id;

        // Modify how the botton looks based on LevelState
        if (state == LevelState.IN_PROGRESS || state == LevelState.COMPLETED)
        {
            // Enable interactability
            button.interactable = true;

            // Keep the colour but set the alpha to 255
            Color buttonColor = new Color(text.color.r, text.color.g, text.color.b, 255);
            text.color = buttonColor;
        }
    }

    // Send the user to the correct scene
    public void GoToScene()
    {
        int buildIndex = SceneUtility.GetBuildIndexByScenePath(scene.ToString());

        // A return of -1 means the scene does not exist
        if (buildIndex == -1)
        {
            Debug.LogError("The scene " + scene.ToString() + " could not be found.");
        } else
        {
            // Load the appropiate scene
            SceneManager.LoadScene(scene.ToString(), LoadSceneMode.Single);
        }
    }
}