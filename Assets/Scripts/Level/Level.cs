using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Level : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] public string id;
    [SerializeField] public Scence scence;
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
}