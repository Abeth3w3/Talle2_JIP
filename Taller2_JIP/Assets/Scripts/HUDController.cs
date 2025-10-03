using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    public TMP_Text timeText, scoreText, coinsText, killsText, deathsText;

    void Update()
    {
        timeText.text = "Tiempo: " + GameManager.Instance.GetFormattedTime();
        scoreText.text = "Score: " + GameManager.Instance.Score;
        coinsText.text = "Coins: " + GameManager.Instance.Coins;
        killsText.text = "Kills: " + GameManager.Instance.Kills;
        deathsText.text = "Deaths: " + GameManager.Instance.Deaths;
    }
}
