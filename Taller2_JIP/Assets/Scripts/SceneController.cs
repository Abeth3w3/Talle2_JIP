using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string nextScene;

    public void EndLevel()
    {
        SceneManager.LoadScene(nextScene);
    }
}
