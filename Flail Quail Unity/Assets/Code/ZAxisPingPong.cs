using UnityEngine;

public class ZAxisPingPong : MonoBehaviour
{
    public float amplitude = 45f;
    public float speed = 90f;           // degrees per second
    public float initialOffset = 0f;

    private float angle;
    private float direction = 1f;

    void Start()
    {
        angle = initialOffset;
    }

    void Update()
    {
        angle += speed * direction * Time.unscaledDeltaTime;

        if (Mathf.Abs(angle) >= amplitude)
        {
            direction *= -1f;
            angle = Mathf.Clamp(angle, -amplitude, amplitude);
        }

        transform.localRotation = Quaternion.Euler(0f, 0f, angle);
    }
}