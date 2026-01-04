using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int toSceneId;

    public void Go()
    {
        GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(toSceneId);
    }
}
