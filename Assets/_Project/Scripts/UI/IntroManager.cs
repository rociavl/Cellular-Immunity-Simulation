using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject introPanel;
    public BacteriaSpawner bacteriaSpawner;
    public HealthPickupSpawner healthPickupSpawner;

    private static bool hasSeenIntro = false;

    void Start()
    {
        // Skip intro if already seen (e.g., after restart)
        if (hasSeenIntro)
        {
            StartGame();
            return;
        }

        // Pause game and show intro
        Time.timeScale = 0f;
        introPanel.SetActive(true);

        // Unlock cursor for menu interaction
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        hasSeenIntro = true;

        // Hide intro and start game
        introPanel.SetActive(false);
        Time.timeScale = 1f;

        // Lock cursor for gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Start the spawners
        if (bacteriaSpawner != null)
            bacteriaSpawner.StartSpawning();
        if (healthPickupSpawner != null)
            healthPickupSpawner.StartSpawning();
    }

    // Reset intro state (call this from main menu if needed)
    public static void ResetIntro()
    {
        hasSeenIntro = false;
    }
}
