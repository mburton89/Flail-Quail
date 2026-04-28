using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;           // for LocalizedString
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject gameOverMenu;

    int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;

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
        CheckForNewBestScore();
        Time.timeScale = 0;
    }

    public void Restart()
    {
        SoundManager.Instance.PlayDrinkSound();
        SceneManager.LoadScene(0);
    }

    public void AddPoint()
    {
        score++;
        scoreText.SetText(score.ToString());
    }

    void CheckForNewBestScore()
    {
        string localizedBestScoreLabel;

        // Get the currently active locale from the Localization package
        Locale currentLocale = LocalizationSettings.SelectedLocale;

        if (currentLocale != null)
        {
            string localeCode = currentLocale.Identifier.Code;   // e.g. "fr", "en", "de-CH", "de"

            switch (localeCode)
            {
                case "fr":
                    localizedBestScoreLabel = "Meilleur score : ";
                    break;

                case "de":     // German / Swiss German
                case "de-CH":  // Explicit Swiss German if you have a custom locale
                    localizedBestScoreLabel = "Beste Punktzahl: ";
                    break;

                case "en":
                default:
                    localizedBestScoreLabel = "Best score: ";
                    break;
            }
        }
        else
        {
            // Fallback in case localization hasn't initialized yet
            localizedBestScoreLabel = "Best score: ";
        }

        int currentBestScore = PlayerPrefs.GetInt("BestScore");
        
        if (score > currentBestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }

        bestScoreText.SetText(localizedBestScoreLabel + PlayerPrefs.GetInt("BestScore"));
    }
}