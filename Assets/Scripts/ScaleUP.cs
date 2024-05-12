using UnityEngine;

public class ScaleUP : MonoBehaviour
{
    public float scaleDuration = 0.3f; // Time in seconds to scale from 0 to target
    public float targetScale = 0.5f; // Target scale to reach
    public AnimationCurve scaleCurve; // Animation curve for custom scaling

    private Vector3 initialScale = Vector3.zero; // Initial scale of the object
    private float elapsedTime = 0f; // Time elapsed since start of scaling

    void Start()
    {
        // Set the initial scale to (0, 0, 0)
        transform.localScale = initialScale;
    }

    void Update()
    {
        // Incrementally scale up towards the target scale based on time and animation curve
        if (elapsedTime < scaleDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / scaleDuration);
            float scaleProgress = scaleCurve.Evaluate(t); // Evaluate the animation curve at time t
            transform.localScale = Vector3.Lerp(initialScale, initialScale + Vector3.one * targetScale, scaleProgress);
        }
        else
        {
            // Ensure final scale is exactly the target scale
            transform.localScale = initialScale + Vector3.one * targetScale;
        }
    }
}
