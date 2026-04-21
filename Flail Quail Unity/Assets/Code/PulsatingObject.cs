using UnityEngine;

public class PulsatingObject : MonoBehaviour
{
    [Header("Pulsating Scale Settings")]
    [Tooltip("Minimum size the object will shrink to")]
    public float minSize = 0.8f;

    [Tooltip("Maximum size the object will grow to")]
    public float maxSize = 1.2f;

    [Tooltip("How fast the object pulses (higher = faster)")]
    public float pulseSpeed = 2f;

    [Tooltip("Optional phase offset to stagger multiple objects")]
    public float phaseOffset = 0f;

    private Vector3 originalScale;
    private float time;

    void Start()
    {
        // Remember the object's starting scale
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Increment time for smooth pulsing
        time += Time.deltaTime * pulseSpeed;

        // Calculate scale factor using sine wave (goes smoothly from -1 to 1)
        float scaleFactor = Mathf.Sin(time + phaseOffset);

        // Map the sine value from -1..1 to minSize..maxSize
        float currentScale = Mathf.Lerp(minSize, maxSize, (scaleFactor + 1f) / 2f);

        // Apply the new scale (uniform in all directions)
        transform.localScale = originalScale * currentScale;
    }
}