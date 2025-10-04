using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem1 : MonoBehaviour
{
    public void Jugar()
    {
        Debug.Log("✅ BOTÓN JUGAR FUNCIONA");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Debug.Log("✅ BOTÓN SALIR FUNCIONA");
        Application.Quit();
    }
}
