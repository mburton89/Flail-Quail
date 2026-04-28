using UnityEngine;

public class Ozempig : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddPoint();
        SoundManager.Instance.PlayOzempigSound();
        Quail.Instance.LoseWeight();
        Destroy(gameObject);
    }
}
