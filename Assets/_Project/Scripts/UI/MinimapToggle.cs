using UnityEngine;

public class MinimapToggle : MonoBehaviour
{
    [Header("Minimap UI Elements")]
    public GameObject minimapDisplay;
    public GameObject minimapBorder;

    [Header("Settings")]
    public KeyCode toggleKey = KeyCode.M;

    private bool isVisible = true;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isVisible = !isVisible;
            SetMinimapVisible(isVisible);
        }
    }

    void SetMinimapVisible(bool visible)
    {
        if (minimapDisplay != null)
            minimapDisplay.SetActive(visible);

        if (minimapBorder != null)
            minimapBorder.SetActive(visible);
    }
}
