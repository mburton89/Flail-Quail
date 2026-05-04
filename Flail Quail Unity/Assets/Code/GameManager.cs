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
    public TextMeshProUGUI countdownText;

    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        }

    }

    private void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(CountdownToStart());
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        CheckForNewBestScore();
        Time.timeScale = 0;
    }

    //"321" countdown
    IEnumerator CountdownToStart()
    {
        //hiding the score text right away
        scoreText.gameObject.SetActive(false); 
    
        countdownText.gameObject.SetActive(true);

        int count = 3;
        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSecondsRealtime(0.5f);
            count--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(0.3f);

        countdownText.gameObject.SetActive(false);

        //this shows the score text now that the game is starting
        scoreText.gameObject.SetActive(true); 

        Time.timeScale = 1;
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

    public void ShowCustomText(string textToShow)
    {
        StartCoroutine(ShowCustomTextCo(textToShow));
    }

    private IEnumerator ShowCustomTextCo(string textToShow)
    {
        scoreText.SetText(textToShow);
        yield return new WaitForSeconds(1.5f);
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