using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public int score = 0;
    public bool isGameOver = false;

    // Static variable to remember if we already watched the intro in this session
    private static bool hasSeenIntro = false;

    [Header("References")]
    public GameObject introPanel;          // The Menu UI
    public BacteriaSpawner bacteriaSpawner; // Reference to enemy spawner
    public HealthPickupSpawner healthSpawner; // Reference to health spawner

    // Events for UI updates
    public System.Action<int> OnScoreChanged;
    public System.Action OnGameOver;

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {
        // Logic to decide if we show menu or start playing directly (restart)
        if (hasSeenIntro)
        {
            StartGameplay();
        }
        else
        {
            ShowIntro();
        }
    }

    void ShowIntro()
    {
        // Pause game and show cursor
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (introPanel != null)
            introPanel.SetActive(true);
    }

    // LINK THIS FUNCTION TO YOUR "PLAY" BUTTON
    public void StartGameButton()
    {
        hasSeenIntro = true;
        StartGameplay();
    }

    void StartGameplay()
    {
        // Unpause and hide cursor
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isGameOver = false;

        if (introPanel != null)
            introPanel.SetActive(false);

        // Tell spawners to start working NOW (not before)
        if (bacteriaSpawner != null)
        {
            bacteriaSpawner.StartSpawning();
        }

        if (healthSpawner != null) healthSpawner.StartSpawning();
    }

    public void AddScore(int points)
    {
        if (isGameOver) return;

        score += points;
        OnScoreChanged?.Invoke(score);
    }

    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        OnGameOver?.Invoke();

        // Unlock cursor so player can interact with UI
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Slow down time for dramatic effect
        Time.timeScale = 0.3f;
    }

    public void RestartGame()
    {
        // Reset time before reloading
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}