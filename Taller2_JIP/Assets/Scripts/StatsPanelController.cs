using TMPro;
using UnityEngine;

public class StatsPanelController : MonoBehaviour
{
    public static StatsPanelController Instance;

    public TMP_Text coinsText, killsText, deathsText, scoreText, timeText;

    void Awake() { Instance = this; }

    public void Refresh()
    {
        coinsText.text = "Coins: " + GameManager.Instance.Coins;
        killsText.text = "Kills: " + GameManager.Instance.Kills;
        deathsText.text = "Deaths: " + GameManager.Instance.Deaths;
        scoreText.text = "Score: " + GameManager.Instance.Score;
        timeText.text = "Time: " + GameManager.Instance.GetFormattedTime();
    }
}
