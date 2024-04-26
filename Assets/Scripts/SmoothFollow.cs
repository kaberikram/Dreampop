using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    public Transform cameraTransform; // Camera or parent object to follow
    public float smoothSpeed = 0.125f; // Smoothing factor
    public float distanceZ = 1f; // Distance in Z axis

    private Vector3 offset;

    void Start()
    {
        // Calculate initial offset
        offset = transform.position - cameraTransform.position;
    }

    void FixedUpdate()
    {
        // Calculate the desired position based on camera's forward direction
        Vector3 desiredPosition = cameraTransform.position + cameraTransform.forward * distanceZ;

        // Smoothly interpolate towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Update the position
        transform.position = smoothedPosition;

        // Update rotation to match camera's rotation
        transform.rotation = Quaternion.LookRotation(cameraTransform.forward, cameraTransform.up);
    }
}
