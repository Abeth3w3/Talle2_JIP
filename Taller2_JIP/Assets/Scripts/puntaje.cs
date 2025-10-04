using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
public class Puntaje : MonoBehaviour
{
   private float puntos;

    private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    
    public void SumarPuntos(float puntosEntrada)
    {
        puntos += puntosEntrada;
    }
}


