using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public Animator animator; // arrastra aquí el Animator del panel
    private string sceneToLoad;

    public void FadeToScene(string sceneName)
    {
        sceneToLoad = sceneName;
        animator.SetTrigger("FadeOut");
    }

    // Este se llama desde un evento en la animación cuando termina el fade
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
