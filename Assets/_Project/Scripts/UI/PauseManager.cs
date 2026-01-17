using UnityEngine;
using TMPro;

public class PauseManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject pausePanel;
    public TextMeshProUGUI encyclopediaText;

    [Header("Settings")]
    public KeyCode pauseKey = KeyCode.Escape;

    private bool isPaused = false;
    private int currentCategory = 0;

    private string[] categories = new string[]
    {
        "LEUKOCYTES",
        "BACTERIA",
        "IMMUNE SYSTEM",
        "BLOOD & CIRCULATION",
        "FUN FACTS"
    };

    private string[] encyclopediaContent = new string[]
    {
        // LEUKOCYTES
        "<color=#00FFFF><size=28>LEUKOCYTES (White Blood Cells)</size></color>\n\n" +
        "<color=#FFFFFF>" +
        "• Your body contains 5-10 billion white blood cells\n\n" +
        "• 100 billion new leukocytes are made daily\n\n" +
        "• They live 13-20 days on average\n\n" +
        "• Can squeeze through blood vessel walls to reach infections\n\n" +
        "• They \"smell\" chemicals released by bacteria to track them\n\n" +
        "• Neutrophils are the most common type (60-70%)\n\n" +
        "• Phagocytes literally EAT bacteria to destroy them\n\n" +
        "• Leukocytes can travel up to 30 micrometers per minute\n\n" +
        "• Fever helps leukocytes work faster\n\n" +
        "• Your bone marrow produces all white blood cells</color>",

        // BACTERIA
        "<color=#FF6666><size=28>BACTERIA</size></color>\n\n" +
        "<color=#FFFFFF>" +
        "• Single-celled microorganisms\n\n" +
        "• Can divide every 20 minutes\n\n" +
        "• 1 bacterium can become 1 million in just 7 hours!\n\n" +
        "• Some bacteria are actually helpful (gut bacteria!)\n\n" +
        "• Existed on Earth for 3.5 billion years\n\n" +
        "• Smaller than human cells (1-10 micrometers)\n\n" +
        "• There are more bacteria in your mouth than people on Earth\n\n" +
        "• Some can survive extreme temperatures\n\n" +
        "• Antibiotics kill bacteria but not viruses\n\n" +
        "• 99% of bacteria are harmless or helpful</color>",

        // IMMUNE SYSTEM
        "<color=#66FF66><size=28>THE IMMUNE SYSTEM</size></color>\n\n" +
        "<color=#FFFFFF>" +
        "• First line of defense: skin and mucus\n\n" +
        "• Second line: leukocytes and inflammation\n\n" +
        "• Third line: antibodies (memory cells)\n\n" +
        "• Your immune system remembers every pathogen it fights\n\n" +
        "• That's why vaccines work - they train your immune system\n\n" +
        "• Sleep helps your immune system recover\n\n" +
        "• Stress weakens immune response\n\n" +
        "• Children get sick more because their immune system is learning\n\n" +
        "• The thymus gland trains T-cells to recognize threats</color>",

        // BLOOD & CIRCULATION
        "<color=#FF66FF><size=28>BLOOD & CIRCULATION</size></color>\n\n" +
        "<color=#FFFFFF>" +
        "• Blood travels 19,000 km through your body daily\n\n" +
        "• Red blood cells carry oxygen, white cells fight infection\n\n" +
        "• Platelets help blood clot wounds\n\n" +
        "• Your heart pumps 7,500 liters of blood daily\n\n" +
        "• Blood makes a complete circuit in about 60 seconds\n\n" +
        "• Red blood cells live about 120 days\n\n" +
        "• Plasma is 92% water</color>",

        // FUN FACTS
        "<color=#FFFF66><size=28>FUN FACTS</size></color>\n\n" +
        "<color=#FFFFFF>" +
        "• You have more bacterial cells than human cells in your body!\n\n" +
        "• Your immune system can detect 1 foreign cell among 1 million\n\n" +
        "• Pus is actually dead white blood cells\n\n" +
        "• Inflammation is your body's alarm system\n\n" +
        "• A sneeze can travel at 160 km/h spreading bacteria\n\n" +
        "• Hand washing removes 99% of bacteria\n\n" +
        "• Your skin is home to 1,000 species of bacteria</color>"
    };

    void Start()
    {
        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Show first category
        UpdateEncyclopedia();
    }

    public void ResumeGame()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NextCategory()
    {
        currentCategory = (currentCategory + 1) % categories.Length;
        UpdateEncyclopedia();
    }

    public void PreviousCategory()
    {
        currentCategory--;
        if (currentCategory < 0)
            currentCategory = categories.Length - 1;
        UpdateEncyclopedia();
    }

    void UpdateEncyclopedia()
    {
        if (encyclopediaText != null)
        {
            encyclopediaText.text = encyclopediaContent[currentCategory];
        }
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
