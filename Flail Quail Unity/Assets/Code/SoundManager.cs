using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public float minPitch;
    public float maxPitch;

    public AudioSource eatSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void PlayEatSound()
    {
        eatSound.Play();
    }
}
