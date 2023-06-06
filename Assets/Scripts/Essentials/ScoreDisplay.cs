using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();

    }

    private void Update()
    {
        if (scoreManager != null)
        {
            scoreText.text = "Score: " + scoreManager.score.ToString();
        }
    }
}