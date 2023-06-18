using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public GameObject enemyObject1;
    public GameObject enemyObject2;

    private const string HighScoreKey = "HighScore";

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        enemyObject1.GetComponent<EnemyHP>().MaxHitpoints = 2f;
    }

    private void Start()
    {
        LoadHighScore(); // Load the high score on start
    }

    public void IncreaseScore(int amount)
    {
        score += amount;
        if (score > highScore)
        {
            highScore = score;
            SaveHighScore(); // Save the new high score
        }
        if (score % 1000 == 0)
        {
            int increaseCount = score / 1000;
            EnemyHP enemyHPScript = enemyObject1.GetComponent<EnemyHP>();

            for (int i = 0; i < increaseCount; i++)
            {
                enemyHPScript.IncreaseHP(1.15f);
            }
        }

        ScoreDisplay.Instance.UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, highScore);
        PlayerPrefs.Save();
    }

    private void LoadHighScore()
    {
        if (PlayerPrefs.HasKey(HighScoreKey))
        {
            highScore = PlayerPrefs.GetInt(HighScoreKey);
        }
        else
        {
            highScore = 0; // Set high score to 0 if it's not already set
            SaveHighScore(); // Save the initial high score
        }
    }

    public void BulletHitEnemy()
    {
        IncreaseScore(50);
    }
}
