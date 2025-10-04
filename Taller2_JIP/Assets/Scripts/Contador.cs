using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public class ContadorTiempo : MonoBehaviour
{
    public TextMeshProUGUI tiempoText; // Arrastra aquí tu texto en el inspector
    private float tiempoTranscurrido = 0f;
    private bool contar = true;

    void Update()
    {
        if (contar)
        {
            tiempoTranscurrido += Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

            tiempoText.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        }
    }

    public void PausarContador()
    {
        contar = false;
    }

    public void ReiniciarContador()
    {
        tiempoTranscurrido = 0f;
        contar = true;
    }
}
