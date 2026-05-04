using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimatorUnscaledUI : MonoBehaviour
{
    [Header("UI Sprite Animation")]
    [Tooltip("List of sprites to cycle through")]
    public List<Sprite> sprites = new List<Sprite>();

    [Tooltip("Time in real seconds each frame is shown")]
    public float frameTime = 0.1f;

    [Tooltip("Should the animation loop?")]
    public bool loop = true;

    [Tooltip("Start playing automatically when enabled?")]
    public bool playOnAwake = true;

    private Image image;
    private int currentIndex = 0;
    private float timer = 0f;
    private bool isPlaying = false;

    private void Awake()
    {
        image = GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError("SpriteAnimatorUnscaledUI requires a UnityEngine.UI.Image component on the same GameObject!", gameObject);
        }
    }

    private void OnEnable()
    {
        // Restart animation when the object (or parent) becomes active
        if (playOnAwake && sprites.Count > 0 && image != null)
        {
            Play();
        }
    }

    private void Update()
    {
        if (!isPlaying || sprites.Count == 0 || image == null)
            return;

        // Unscaled time = works even when Time.timeScale = 0
        timer += Time.unscaledDeltaTime;

        if (timer >= frameTime)
        {
            timer -= frameTime;
            NextFrame();
        }
    }

    private void NextFrame()
    {
        currentIndex++;

        if (currentIndex >= sprites.Count)
        {
            if (loop)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex = sprites.Count - 1;
                isPlaying = false;
                return;
            }
        }

        image.sprite = sprites[currentIndex];
    }

    /// <summary> Start / Restart the animation </summary>
    public void Play()
    {
        if (sprites.Count == 0 || image == null) return;

        isPlaying = true;
        timer = 0f;
        currentIndex = 0;

        // Show first sprite immediately
        image.sprite = sprites[0];
    }

    /// <summary> Stop the animation (keeps current sprite) </summary>
    public void Stop()
    {
        isPlaying = false;
    }

    /// <summary> Reset to first frame and stop </summary>
    public void ResetAnimation()
    {
        Stop();
        if (sprites.Count > 0 && image != null)
        {
            currentIndex = 0;
            image.sprite = sprites[0];
        }
    }

    /// <summary> Jump to a specific frame </summary>
    public void SetFrame(int index)
    {
        if (sprites.Count == 0 || image == null) return;

        currentIndex = Mathf.Clamp(index, 0, sprites.Count - 1);
        image.sprite = sprites[currentIndex];
    }
}