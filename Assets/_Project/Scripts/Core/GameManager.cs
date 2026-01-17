using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Game State")]
    public int score = 0;
    public bool isGameOver = false;

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

        // Optional: Slow down time for dramatic effect
        Time.timeScale = 0.3f;
    }

    public void RestartGame()
    {
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
