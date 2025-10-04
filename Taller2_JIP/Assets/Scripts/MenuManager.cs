using UnityEngine;
using UnityEngine.SceneManagement; // para cargar escenas

public class MenuManager : MonoBehaviour
{
    public Animator animator; // arrastra aquí el Animator del Canvas o Panel

    public void Jugar()
    {
        // este método lo asignas al botón Jugar en el inspector
        animator.SetTrigger("StartGame"); // dispara la animación de fade out
    }

    // este método lo llamará el evento de la animación al final
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Juego"); // cambia "NombreDeTuEscena"
    }
}
