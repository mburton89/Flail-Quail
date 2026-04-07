using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverMenu;

    int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        }

        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void AddPoint()
    {
        score++;
        scoreText.SetText(score.ToString());
    }
}