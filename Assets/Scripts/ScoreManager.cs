using UnityEngine;
using UnityEngine.UI; // Required for using UI Text

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Non-static field

    // Reference to the UI Text object
    public Text scoreText;

    private void Start()
    {
        // Find and assign the Text object in the scene
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        // Update the text with the initial score value
        UpdateScoreText();
    }

    public void IncreaseScore(int amount) // Non-static method
    {
        score += amount;
        Debug.Log("Score: " + score);
        // Update the UI Text
        UpdateScoreText();
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
