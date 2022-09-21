using UnityEngine;
using UnityEngine.UI;

public class ScreenResolution : MonoBehaviour
{
    // Current screen resolution (x & y)
    private Vector2 screenResolution;

    // UI Canvas
    [SerializeField] private Canvas canvas;

    // Canvas Background Aspect Ratio Fitter
    [SerializeField] private AspectRatioFitter backgroundAspectRatio;

    // Canvas Safe area panel
    [SerializeField] private RectTransform safeAreaPanel;

    // Start is called before the first frame update
    void Start()
    {
        // Make sure the aspect ratio fitter is valid
        if (backgroundAspectRatio == null)
            Debug.LogError("The Aspect Ratio Fitter field has not been set.");

        // Store current screen resolution in Vector2
        screenResolution = new Vector2(Screen.width, Screen.height);

        // Update aspect ratio based on screenResolution
        backgroundAspectRatio.aspectRatio = screenResolution.x / screenResolution.y;

        // Update screen resolution and safe area
        AdjustBackgroundAndSafeArea();

    }

    // Update is called once per frame
    void Update()
    {
        // Ignore if the aspectRatioFitter, safeAreaPanel or Canvas is null
        if (backgroundAspectRatio == null || safeAreaPanel == null || canvas == null) return;

        // Update screen resolution and safe area
        AdjustBackgroundAndSafeArea();
    }

    private void AdjustBackgroundAndSafeArea()
    {
        // Check if screen resolution has changed
        if (Screen.width != screenResolution.x || Screen.height != screenResolution.y)
        {
            // Update screenResolution to the new resolution
            screenResolution = new Vector2(Screen.width, Screen.height);

            // Update aspect ratio based on new screenResolution
            backgroundAspectRatio.aspectRatio = screenResolution.x / screenResolution.y;

            /**
             * Update safe are based on new screen resolution
             * 
             * CREDIT: https://forum.unity.com/threads/canvashelper-resizes-a-recttransform-to-iphone-xs-safe-area.521107/
             */
            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= canvas.pixelRect.width;
            anchorMin.y /= canvas.pixelRect.height;
            anchorMax.x /= canvas.pixelRect.width;
            anchorMax.y /= canvas.pixelRect.height;

            safeAreaPanel.anchorMin = anchorMin;
            safeAreaPanel.anchorMax = anchorMax;
        }
    }
}
