using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float gameTime = 600f; // 10 minutes
    private float timer;

    public int score;
    public int scoreGoal = 1000;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        timer = gameTime;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            EndGame(false);
        }
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public void ArchitectScore()
    {
        score += 10; // +10 pts/sec
    }

    public void NavigatorScore(int keys, float timeBonus)
    {
        score += keys * 50;
        score += (int)timeBonus;
    }

    private void EndGame(bool win)
    {
        // Show game over screen
        FindObjectOfType<UIManager>().ShowGameOverScreen(score, GetStats());

        if (win)
        {
            // Save high score
            if (score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }

    private string GetStats()
    {
        // Logic to generate game stats
        float timeElapsed = gameTime - timer;
        int keysCollected = FindObjectOfType<InteractionSystem>().keys.Count;
        // ... more stats

        return $"Time: {timeElapsed:F2}s\nKeys: {keysCollected}";
    }
}
