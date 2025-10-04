using UnityEngine;
using TMPro;

public class ContadorTiempo : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto; // Asigna el texto desde el Inspector
    private float tiempoTranscurrido = 0f;
    private bool contando = true;

    void Update()
    {
        if (contando)
        {
            tiempoTranscurrido += Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
            int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);

            tiempoTexto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
        }
    }

    public void PausarContador()
    {
        contando = false;
    }

    public void ReiniciarContador()
    {
        tiempoTranscurrido = 0f;
        contando = true;
    }

    public float ObtenerTiempo() => tiempoTranscurrido;
}
