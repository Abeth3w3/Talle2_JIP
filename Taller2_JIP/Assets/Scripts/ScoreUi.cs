using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // referencia al texto en pantalla

    void Update()
    {
        // actualiza el texto en tiempo real
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
