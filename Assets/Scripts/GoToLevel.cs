using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int toSceneId;

    public void Go()
    {
        SceneManager.LoadScene(toSceneId);
    }
}
