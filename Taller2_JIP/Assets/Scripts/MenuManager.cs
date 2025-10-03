using UnityEngine;
using UnityEngine.SceneManagement; // para cargar escenas

public class MenuManager : MonoBehaviour
{
    public Animator animator; // arrastra aqu� el Animator del Canvas o Panel

    public void Jugar()
    {
        // este m�todo lo asignas al bot�n Jugar en el inspector
        animator.SetTrigger("StartGame"); // dispara la animaci�n de fade out
    }

    // este m�todo lo llamar� el evento de la animaci�n al final
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Juego"); // cambia "NombreDeTuEscena"
    }
}
