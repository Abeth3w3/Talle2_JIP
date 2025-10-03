using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject instructionsPanel;
    public GameObject statsPanel;

    public void StartGame()
    {
        GameManager.Instance.ResetForNewRun();
        SceneManager.LoadScene("Castle");
    }

    public void ShowInstructions(bool show) => instructionsPanel.SetActive(show);

    public void ShowStats(bool show)
    {
        statsPanel.SetActive(show);
        if (show) StatsPanelController.Instance.Refresh();
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
