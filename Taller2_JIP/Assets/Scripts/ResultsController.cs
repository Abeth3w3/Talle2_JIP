using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultsController : MonoBehaviour
{
    public TMP_Text coinsText, killsText, deathsText, scoreText, timeText;

    void Start()
    {
        coinsText.text = "Coins: " + GameManager.Instance.Coins;
        killsText.text = "Kills: " + GameManager.Instance.Kills;
        deathsText.text = "Deaths: " + GameManager.Instance.Deaths;
        scoreText.text = "Score: " + GameManager.Instance.Score;
        timeText.text = "Time: " + GameManager.Instance.GetFormattedTime();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
