using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText; // Use TMP_Text instead of Text

    private GameManager gameManager;

    private void Start()
    {
        // Find and assign the TextMeshPro Text object in the scene
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        // Find the GameManager instance in the scene
        gameManager = FindObjectOfType<GameManager>();
        // Update the text with the initial score value
        UpdateScoreText();
    }

    public void IncreaseScore(int amount)
    {
        if (gameManager != null && gameManager.CurrentState == GameState.GamePlaying)
        {
            score += amount;
            Debug.Log("Score: " + score);
            UpdateScoreText();
            if (score > 29)
            {
                gameManager.EndGame();
            }
        }
        else
        {
            Debug.LogWarning("Score can only be increased during the playing state.");
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString("00");
        }
    }

}
