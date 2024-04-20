using UnityEngine;

public class TagCycle : MonoBehaviour
{
    public AudioClip triggerSound; // Sound to play when the trigger activates
    private AudioSource audioSource; // Reference to the AudioSource component
    private Renderer rend; // Reference to the Renderer component
    private Material material; // Reference to the material
    private int sequenceIndex = 0; // Index to keep track of the sequence

    // Array to store the sequences of material properties
    private Vector3[] sequences = { new Vector3(0, 0, 0), new Vector3(1, 0, 0), new Vector3(1, 1, 0), new Vector3(1, 1, 1) };

    // Array to store the tags to cycle through
    private string[] tags = { "RedFinger", "BlueFinger", "YellowFinger", "GreenFinger" };
    private int tagIndex = 0; // Index to keep track of the current tag

    // Speed of lerping
    public float lerpSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Renderer component attached to the same GameObject
        rend = GetComponent<Renderer>();

        // Ensure Renderer component is not null
        if (rend == null)
        {
            Debug.LogError("Renderer component is not found!");
            enabled = false; // Disable the script
            return;
        }

        // Get the material of the Renderer component
        material = rend.material;
        // Get the AudioSource component attached to the same GameObject
        audioSource = GetComponent<AudioSource>();

        // Ensure AudioSource component is not null
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is not found!");
            enabled = false; // Disable the script
            return;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for F key press
        if (Input.GetKeyDown(KeyCode.F))
        {
            audioSource.PlayOneShot(triggerSound);

            // Increment the sequence index
            sequenceIndex = (sequenceIndex + 1) % sequences.Length;

            // Increment the tag index
            tagIndex = (tagIndex + 1) % tags.Length;
            // Change the tag of the GameObject to the new tag
            gameObject.tag = tags[tagIndex];
            Debug.Log("Tag changed to: " + tags[tagIndex]);
        }

        // Smoothly interpolate between the current and target values
        Vector3 targetValues = sequences[sequenceIndex];
        float rbValue = Mathf.Lerp(material.GetFloat("_RB"), targetValues.x, Time.deltaTime * lerpSpeed);
        float grbValue = Mathf.Lerp(material.GetFloat("_GRB"), targetValues.y, Time.deltaTime * lerpSpeed);
        float grbyValue = Mathf.Lerp(material.GetFloat("_GRBY"), targetValues.z, Time.deltaTime * lerpSpeed);

        // Set the material properties
        material.SetFloat("_RB", rbValue);
        material.SetFloat("_GRB", grbValue);
        material.SetFloat("_GRBY", grbyValue);
    }
}
