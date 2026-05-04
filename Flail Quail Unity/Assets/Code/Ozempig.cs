using UnityEngine;

public class Ozempig : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.Instance.AddPoint();
        GameManager.Instance.ShowCustomText("Ozem-Pig");
        SoundManager.Instance.PlayOzempigSound();
        Quail.Instance.LoseWeight();
        Destroy(gameObject);
    }
}
