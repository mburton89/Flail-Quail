using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameObject gameOverMenu;

    int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI countdownText;

    private bool canRestart = false;
    private float restartDelay = 0.5f;

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

        // Start the delay before allowing restart
        StartCoroutine(EnableRestartAfterDelay());
    }

    private IEnumerator EnableRestartAfterDelay()
    {
        yield return new WaitForSecondsRealtime(restartDelay);
        canRestart = true;
    }

    public void Restart()
    {
        if (!canRestart) return;           // Block restart during the delay

        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    // "321" countdown
    IEnumerator CountdownToStart()
    {
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
        scoreText.gameObject.SetActive(true);

        Time.timeScale = 1;
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

        Locale currentLocale = LocalizationSettings.SelectedLocale;
        if (currentLocale != null)
        {
            string localeCode = currentLocale.Identifier.Code;

            switch (localeCode)
            {
                case "fr":
                    localizedBestScoreLabel = "Meilleur score : ";
                    break;
                case "de":
                case "de-CH":
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