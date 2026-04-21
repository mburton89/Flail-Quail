using UnityEngine;

public class BobbingAndMovingObject : MonoBehaviour
{
    [Header("Bobbing Settings")]
    [Tooltip("How far the object bobs up and down")]
    public float bobRange = 0.5f;

    [Tooltip("Speed of the bobbing motion (higher = faster)")]
    public float bobSpeed = 2f;

    [Tooltip("Optional phase offset for timing")]
    public float phaseOffset = 0f;

    [Header("Movement Settings")]
    [Tooltip("How fast the object moves to the left (in units per second)")]
    public float moveSpeed = 2f;

    private Vector3 startPosition;
    private float time;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Update time for bobbing
        time += Time.deltaTime * bobSpeed;

        // Calculate vertical bobbing using sine wave
        float yOffset = Mathf.Sin(time + phaseOffset) * bobRange;

        // Calculate horizontal movement (moving left = negative X)
        float xMovement = -moveSpeed * Time.deltaTime;

        // Apply both bobbing and movement
        transform.position = new Vector3(
            transform.position.x + xMovement,           // Move left continuously
            startPosition.y + yOffset,                  // Bob up and down from original Y
            startPosition.z                             // Keep Z unchanged
        );
    }
}