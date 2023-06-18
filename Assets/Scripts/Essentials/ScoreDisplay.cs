using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public static ScoreDisplay Instance; // Singleton instance

    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public GameObject scoreTextObject;
    public GameObject highScoreTextObject;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        scoreText = scoreTextObject.GetComponent<TextMeshProUGUI>();
        highScoreText = highScoreTextObject.GetComponent<TextMeshProUGUI>();

        scoreManager = FindObjectOfType<ScoreManager>();

        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        if (scoreText != null && highScoreText != null)
        {
            scoreText.text = "Score: " + scoreManager.GetScore().ToString();
            highScoreText.text = "High Score: " + scoreManager.GetHighScore().ToString();
        }
    }
}
