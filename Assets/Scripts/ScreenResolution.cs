using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    // Current screen resolution (x & y)
    private Vector2 screenResolution;

    // Canvas Background Aspect Ratio Fitter
    [SerializeField] AspectRatioFitter aspectRatioFitter;

    // Start is called before the first frame update
    void Start()
    {

        // Make sure the aspect ratio fitter is valid
        if (aspectRatioFitter == null) 
            Debug.LogError("The Aspect Ratio Fitter field has not been set.");

        // Store current screen resolution in Vector2
        screenResolution = new Vector2(Screen.width, Screen.height);

        // Update aspect ratio based on screenResolution
        aspectRatioFitter.aspectRatio = screenResolution.x / screenResolution.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Ignore if the aspectRatioFitter is null
        if (aspectRatioFitter == null) return;

        // Screen resolution has changed
        if (Screen.width != screenResolution.x || Screen.height != screenResolution.y)
        {
            // Update screenResolution to the new resolution
            screenResolution = new Vector2(Screen.width, Screen.height);

            // Update aspect ratio based on new screenResolution
            aspectRatioFitter.aspectRatio = screenResolution.x / screenResolution.y;
        }
    }
}
