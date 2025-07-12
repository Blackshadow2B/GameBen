using UnityEngine;

public class SplitScreenManager : MonoBehaviour
{
    public Camera architectCamera;
    public Camera navigatorCamera;

    public enum SplitScreenType { Horizontal, Vertical }
    public SplitScreenType splitScreenType = SplitScreenType.Horizontal;

    private void Start()
    {
        // Configure ArchitectCamera (orthographic, top-down)
        // architectCamera.orthographic = true;
        // ...

        // Configure NavigatorCamera (perspective, 3rd person)
        // navigatorCamera.orthographic = false;
        // ...

        SetSplitScreen();
    }

    public void SetSplitScreen()
    {
        float screenAspect = (float)Screen.width / Screen.height;

        if (splitScreenType == SplitScreenType.Horizontal)
        {
            architectCamera.rect = new Rect(0, 0.5f, 1, 0.5f);
            navigatorCamera.rect = new Rect(0, 0, 1, 0.5f);
        }
        else
        {
            if (screenAspect > 1.7f) // 16:9 or wider
            {
                architectCamera.rect = new Rect(0, 0, 0.5f, 1);
                navigatorCamera.rect = new Rect(0.5f, 0, 0.5f, 1);
            }
            else // 4:3 or narrower
            {
                architectCamera.rect = new Rect(0, 0.5f, 1, 0.5f);
                navigatorCamera.rect = new Rect(0, 0, 1, 0.5f);
            }
        }
    }

    public void ToggleSplitScreen()
    {
        splitScreenType = (splitScreenType == SplitScreenType.Horizontal) ? SplitScreenType.Vertical : SplitScreenType.Horizontal;
        SetSplitScreen();
    }
}
