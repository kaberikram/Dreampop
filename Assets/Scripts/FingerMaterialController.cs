using UnityEngine;

public class FingerMaterialController : MonoBehaviour
{
    public GameObject[] targetObjects; // Array of objects whose tag and material properties will be changed
    public GameObject triggerObject; // Reference to the object whose trigger will activate the changes
    public AudioClip triggerSound; // Sound to play when the trigger activates

    private AudioSource audioSource; // Reference to the AudioSource component
    private Renderer[] rends; // Array of Renderers of the target objects
    private Material[] materials; // Array of materials of the target objects
    private bool isTriggered = false; // Flag to track if trigger is activated
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
        // Initialize arrays
        rends = new Renderer[targetObjects.Length];
        materials = new Material[targetObjects.Length];

        // Get the Renderer components attached to the target objects
        for (int i = 0; i < targetObjects.Length; i++)
        {
            rends[i] = targetObjects[i].GetComponent<Renderer>();

            // Ensure Renderer component is not null
            if (rends[i] == null)
            {
                Debug.LogError("Renderer component is not found on target object " + i + "!");
                enabled = false; // Disable the script
                return;
            }

            // Get the material of the Renderer component
            materials[i] = rends[i].material;
        }

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
        // Check for trigger activation
        if (isTriggered)
        {
            // Play the trigger sound
            audioSource.PlayOneShot(triggerSound);

            // Increment the sequence index
            sequenceIndex = (sequenceIndex + 1) % sequences.Length;

            // Increment the tag index
            tagIndex = (tagIndex + 1) % tags.Length;

            // Change the tag of all target objects to the new tag
            for (int i = 0; i < targetObjects.Length; i++)
            {
                targetObjects[i].tag = tags[tagIndex];
                Debug.Log("Tag changed to: " + tags[tagIndex] + " for target object " + i);
            }

            // Reset trigger flag
            isTriggered = false;
        }

        // Smoothly interpolate between the current and target values for each target object
        Vector3 targetValues = sequences[sequenceIndex];
        for (int i = 0; i < targetObjects.Length; i++)
        {
            float rbValue = Mathf.Lerp(materials[i].GetFloat("_RB"), targetValues.x, Time.deltaTime * lerpSpeed);
            float grbValue = Mathf.Lerp(materials[i].GetFloat("_GRB"), targetValues.y, Time.deltaTime * lerpSpeed);
            float grbyValue = Mathf.Lerp(materials[i].GetFloat("_GRBY"), targetValues.z, Time.deltaTime * lerpSpeed);

            // Set the material properties for each target object
            materials[i].SetFloat("_RB", rbValue);
            materials[i].SetFloat("_GRB", grbValue);
            materials[i].SetFloat("_GRBY", grbyValue);
        }
    }

    // OnTriggerStay is called once per frame for every Collider other that is touching the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the trigger object
        if (other.gameObject == triggerObject)
        {
            // Set trigger flag
            isTriggered = true;
        }
    }
}
