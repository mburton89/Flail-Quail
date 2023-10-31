using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.Instance.AddPoint();
    }
}
