using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class BubbleStart : BubblePopManagerBase
{

    private bool colliderDisabled = false;

    public GameObject ObjectHolder;

    public GameObject Spawn;



    // Reference to the AudioSource component
    private AudioSource audioSource;
    // Reference to the ScoreManager instance
    private GameManager gameManager;

    protected override void Start()
    {
        Spawn.SetActive(false);
        base.Start();

        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Find the GameManager instance in the scene
        gameManager = FindObjectOfType<GameManager>();
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BlueFinger"))
        {

            ObjectHolder.SetActive(false);
            BubblePop();
            // Disable the collider
            DisableCollider();
            // Play the sound
            PlayPopSound();
            gameManager.StartGame();
            Spawn.SetActive(true);


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
