using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    int score = 0;
    public TextMeshProUGUI scoreText;

    void Awake()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        score++;
        scoreText.SetText(score.ToString());
    }
}
