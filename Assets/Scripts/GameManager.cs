using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState { GameStart, GamePlaying, GameEnd, GameRestart }

public class GameManager : MonoBehaviour
{
    public float gameDuration = 120f; // 2 minutes
    private float timer = 0f;
    private float remainingTime = 0f; // Store remaining time when game ends prematurely
    public Image timerImage;

    private GameState currentState = GameState.GameStart;

    // Reference to the ScoreManager instance
    private ScoreManager scoreManager;

    private void Start()
    {
        // Find the ScoreManager instance in the scene
        scoreManager = FindObjectOfType<ScoreManager>();

    }

    private void Update()
    {
        switch (currentState)
        {
            case GameState.GamePlaying:
                // Update the timer
                timer += Time.deltaTime;
                // Check if game duration has elapsed
                if (timer >= gameDuration)
                {
                    EndGame();
                }
                break;
                // Handle other game states if needed...
        }

        UpdateUITimer();

    }

    private void UpdateUITimer()
    {
        // If the game is over, don't update the timer UI
        if (currentState == GameState.GameEnd)
        {
            return;
        }

        // Map timer value between 0 and 120 to fill amount between 1 and 0
        float fillAmount = 1f - (timer / gameDuration);
        // Set fill amount to UI Image
        timerImage.fillAmount = fillAmount;
    }

    public void StartGame()
    {
        // Transition to GamePlaying state
        currentState = GameState.GamePlaying;
        Debug.Log("Game Started!");
    }

    public void EndGame()
    {
        // Transition to GameEnd state
        currentState = GameState.GameEnd;
        // Store remaining time if game ends prematurely
        remainingTime = gameDuration - timer;
        Debug.Log("Game Over!");
        StartCoroutine(RestartGameWithDelay(1.5f)); // Change the delay time as needed
    }

    private IEnumerator RestartGameWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        RestartGame();
    }

    public void RestartGame()
    {
        // Transition to GameRestart state
        currentState = GameState.GameRestart;
    }

    // Getter for the current game state
    public GameState CurrentState => currentState;

    // Method to resume the timer if game ends prematurely
    public void ResumeTimer()
    {
        if (currentState == GameState.GameEnd)
        {
            // Transition back to playing state
            currentState = GameState.GamePlaying;
            // Restart the timer with remaining time
            timer = gameDuration - remainingTime;
            Debug.Log("Game Resumed!");
        }
    }
}
