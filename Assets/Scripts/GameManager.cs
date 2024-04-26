using UnityEngine;

public enum GameState { GameStart, GamePlaying, GameEnd }

public class GameManager : MonoBehaviour
{
    public float gameDuration = 120f; // 2 minutes
    private float timer = 0f;
    private GameState currentState = GameState.GameStart;

    // Reference to the ScoreManager instance
    private ScoreManager scoreManager;

    private void Start()
    {
        // Find the ScoreManager instance in the scene
        scoreManager = FindObjectOfType<ScoreManager>();
        StartGame();

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

        // // Check for the "S" key press to start the game
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     StartGame();
        // }
    }

    private void StartGame()
    {
        // Transition to GamePlaying state
        currentState = GameState.GamePlaying;
        Debug.Log("Game Started!");
    }

    private void EndGame()
    {
        // Transition to GameEnd state
        currentState = GameState.GameEnd;
        Debug.Log("Game Over!");
    }

    // Getter for the current game state
    public GameState CurrentState => currentState;
}
