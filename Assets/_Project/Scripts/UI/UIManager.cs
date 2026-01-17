using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public PlayerHealth playerHealth;
    public GameManager gameManager;

    [Header("Health UI")]
    public Slider healthBar;
    public Image healthFill;
    public TextMeshProUGUI healthText;
    public Color healthyColor = new Color(0.2f, 0.8f, 0.2f);
    public Color damagedColor = new Color(0.8f, 0.2f, 0.2f);

    [Header("Score UI")]
    public TextMeshProUGUI scoreText;

    [Header("Crosshair")]
    public Image crosshair;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public Button restartButton;
    public Button quitButton;

    void Start()
    {
        // Subscribe to events
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthUI;
        }

        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }

        if (gameManager != null)
        {
            gameManager.OnScoreChanged += UpdateScoreUI;
            gameManager.OnGameOver += ShowGameOver;
        }

        // Initialize UI
        UpdateScoreUI(0);

        // Hide game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }

        // Setup buttons
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(() => GameManager.Instance?.RestartGame());
        }
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(() => GameManager.Instance?.QuitGame());
        }
    }

    void OnDestroy()
    {
        // Unsubscribe from events
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged -= UpdateHealthUI;
        }

        if (gameManager != null)
        {
            gameManager.OnScoreChanged -= UpdateScoreUI;
            gameManager.OnGameOver -= ShowGameOver;
        }
    }

    void UpdateHealthUI(int current, int max)
    {
        if (healthBar != null)
        {
            healthBar.maxValue = max;
            healthBar.value = current;
        }

        if (healthText != null)
        {
            healthText.text = $"{current} / {max}";
        }

        // Change color based on health percentage
        if (healthFill != null)
        {
            float healthPercent = (float)current / max;
            healthFill.color = Color.Lerp(damagedColor, healthyColor, healthPercent);
        }
    }

    void UpdateScoreUI(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {newScore}";
        }
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        if (finalScoreText != null && gameManager != null)
        {
            finalScoreText.text = $"Final Score: {gameManager.score}";
        }

        // Hide crosshair
        if (crosshair != null)
        {
            crosshair.gameObject.SetActive(false);
        }
    }
}
