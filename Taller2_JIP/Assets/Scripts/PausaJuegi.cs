using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PausaJuegi : MonoBehaviour
{

    public GameObject menuPausa;
    public bool juegoPausado = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            if (juegoPausado)
            {
                Renaudar();
            }
            else
            {
                Pausar();
            }
    }
    public void Renaudar()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;
        juegoPausado = false;
    }

    public void Pausar()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;
        juegoPausado = true;
    }
}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
