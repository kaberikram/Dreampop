using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BubblePopManager : BubblePopManagerBase
{
    [SerializeField] private int ScoreAmount = 1;
    // Flag to track if the collider has been disabled
    private bool colliderDisabled = false;

    // Reference to the AudioSource component
    private AudioSource audioSource;
    // Reference to the ScoreManager instance
    private ScoreManager scoreManager;
    // Reference to the GameManager instance
    private GameManager gameManager;

    protected override void Start()
    {
        base.Start();
        scoreManager = FindObjectOfType<ScoreManager>();

        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Find the GameManager instance in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        // Check if the collider hasn't been disabled yet and the game state is playing
        if (!colliderDisabled && gameManager != null && gameManager.CurrentState == GameState.GamePlaying)
        {
            switch (sphereColor)
            {
                case SphereColor.Blue:
                    if (other.gameObject.CompareTag("BlueFinger"))
                    {
                        Debug.Log("blue");
                        BubblePop();
                        // Disable the collider
                        DisableCollider();
                        // Play the sound
                        PlayPopSound();
                        // Increase score
                        if (scoreManager != null)
                        {
                            scoreManager.IncreaseScore(ScoreAmount); // Adjust score increment as needed
                        }
                        else
                        {
                            Debug.LogError("ScoreManager instance not found!");
                        }
                    }
                    break;
                case SphereColor.Green:
                    if (other.gameObject.CompareTag("GreenFinger"))
                    {
                        Debug.Log("green");
                        BubblePop();
                        // Disable the collider
                        DisableCollider();
                        // Play the sound
                        PlayPopSound();
                        // Increase score
                        if (scoreManager != null)
                        {
                            scoreManager.IncreaseScore(ScoreAmount); // Adjust score increment as needed
                        }
                        else
                        {
                            Debug.LogError("ScoreManager instance not found!");
                        }
                    }
                    break;
                case SphereColor.Yellow:
                    if (other.gameObject.CompareTag("YellowFinger"))
                    {
                        Debug.Log("yellow");
                        BubblePop();
                        // Disable the collider
                        DisableCollider();
                        // Play the sound
                        PlayPopSound();
                        // Increase score
                        if (scoreManager != null)
                        {
                            scoreManager.IncreaseScore(ScoreAmount); // Adjust score increment as needed
                        }
                        else
                        {
                            Debug.LogError("ScoreManager instance not found!");
                        }
                    }
                    break;
                case SphereColor.Red:
                    if (other.gameObject.CompareTag("RedFinger"))
                    {
                        Debug.Log("red");
                        BubblePop();
                        // Disable the collider
                        DisableCollider();
                        // Play the sound
                        PlayPopSound();
                        // Increase score
                        if (scoreManager != null)
                        {
                            scoreManager.IncreaseScore(ScoreAmount); // Adjust score increment as needed
                        }
                        else
                        {
                            Debug.LogError("ScoreManager instance not found!");
                        }
                    }
                    break;
            }
        }
    }

    // Function to disable the collider
    private void DisableCollider()
    {
        // Get the collider component and disable it
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
            // Set the flag to indicate that the collider has been disabled
            colliderDisabled = true;
        }
    }

    // Function to play the pop sound
    private void PlayPopSound()
    {
        // Check if the AudioSource component is not null and has an AudioClip assigned
        if (audioSource != null && audioSource.clip != null)
        {
            // Play the sound
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}
