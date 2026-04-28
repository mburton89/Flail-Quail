using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public float minPitch;
    public float maxPitch;

    public AudioSource eatSound;
    public AudioSource drinkSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }

    public void PlayEatSound()
    {
        eatSound.pitch = Random.Range(minPitch, maxPitch);
        eatSound.Play();
    }

    public void PlayDrinkSound()
    {
        drinkSound.pitch = Random.Range(minPitch, maxPitch);
        drinkSound.Play();
    }
}
