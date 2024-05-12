using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BubbleEnd : BubblePopManagerBase
{
    public GameObject objectHolder;
    private bool colliderDisabled = false;
    private AudioSource audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
        objectHolder.SetActive(true);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GreenFinger"))
        {
            BubblePop();
            DisableCollider();
            PlayPopSound();
            objectHolder.SetActive(false);


            // Start a coroutine to restart the scene after a delay
            StartCoroutine(RestartSceneWithDelay(1.5f)); // Change the delay time as needed
        }
    }

    private void DisableCollider()
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
            colliderDisabled = true;
        }
    }

    private void PlayPopSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }

    // Coroutine to restart scene after a delay
    private IEnumerator RestartSceneWithDelay(float delay)
    {
        // Wait for the specified delay
        yield return new WaitForSeconds(delay);

        // Restart the scene
        RestartScene();
    }

    public void RestartScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
