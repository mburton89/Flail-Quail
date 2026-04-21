using UnityEngine;

public class Apple : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddPoint();
        SoundManager.Instance.PlayEatSound();
        Quail.Instance.GetFat();
        Destroy(gameObject);
    }

}
