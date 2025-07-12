using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Architect HUD
    public GameObject architectHud;
    public Image tileSelector;
    public Text cooldownText;
    public Image cursorVisual;

    // Navigator HUD
    public GameObject navigatorHud;
    public RawImage minimap;
    public Text keyInventory;
    public Slider healthIndicator;

    // Main Menu
    public GameObject mainMenu;

    // Pause Menu
    public GameObject pauseMenu;

    // Game Over Screen
    public GameObject gameOverScreen;
    public Text scoreText;
    public Text statsText;

    private void Start()
    {
        // Initialize UI elements
        architectHud.GetComponent<Canvas>().worldCamera = FindObjectOfType<SplitScreenManager>().architectCamera;
        navigatorHud.GetComponent<Canvas>().worldCamera = FindObjectOfType<SplitScreenManager>().navigatorCamera;
    }

    public void UpdateArchitectHud()
    {
        // Update architect HUD elements
    }

    public void UpdateNavigatorHud()
    {
        // Update navigator HUD elements
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void HideMainMenu()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void SelectArchitect()
    {
        // Logic to select architect role
        HideMainMenu();
    }

    public void SelectNavigator()
    {
        // Logic to select navigator role
        HideMainMenu();
    }

    public void TogglePauseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Time.timeScale = pauseMenu.activeSelf ? 0 : 1;
    }

    public void ResumeGame()
    {
        TogglePauseMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowGameOverScreen(int score, string stats)
    {
        gameOverScreen.SetActive(true);
        scoreText.text = "Score: " + score;
        statsText.text = stats;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        // Logic to restart the game
        Time.timeScale = 1;
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
