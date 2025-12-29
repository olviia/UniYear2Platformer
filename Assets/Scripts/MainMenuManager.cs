using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public int startSceneId;

    public void StartGame()
    {
        SceneManager.LoadScene(startSceneId);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
