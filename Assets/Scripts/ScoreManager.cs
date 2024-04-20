using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Non-static field
    public Text scoreText; // Reference to the UI Text object

    // Reference to the GameManager instance
    private GameManager gameManager;

    private void Start()
    {
        // Find and assign the Text object in the scene
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // Find the GameManager instance in the scene
        gameManager = FindObjectOfType<GameManager>();
        // Update the text with the initial score value
        UpdateScoreText();
    }

    public void IncreaseScore(int amount) // Non-static method
    {
        // Check if the game is in the playing state
        if (gameManager != null && gameManager.CurrentState == GameState.GamePlaying)
        {
            score += amount;
            Debug.Log("Score: " + score);
            // Update the UI Text
            UpdateScoreText();
        }
        else
        {
            // Optionally, provide feedback or handle score increments when not in the playing state
            Debug.LogWarning("Score can only be increased during the playing state.");
        }
    }

    // Function to update the UI Text with the current score value
    private void UpdateScoreText()
    {
        // Check if the scoreText is not null
        if (scoreText != null)
        {
            // Update the text with the current score value
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
