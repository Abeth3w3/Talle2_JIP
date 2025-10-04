using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; 

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null && GameManager.Instance.HasKey) 
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("Necesitas la llave para abrir la puerta.");
            }
        }
    }
}
