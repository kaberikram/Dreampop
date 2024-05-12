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

    // Calculate the desired rotation based on camera's rotation
    Quaternion desiredRotation = Quaternion.LookRotation(cameraTransform.forward, cameraTransform.up);

    // Keep the z rotation fixed
    desiredRotation.eulerAngles = new Vector3(desiredRotation.eulerAngles.x, desiredRotation.eulerAngles.y, transform.rotation.eulerAngles.z);

    // Update rotation to match desired rotation
    transform.rotation = desiredRotation;
}

}
