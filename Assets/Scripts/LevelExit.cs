using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public int nextSceneId;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LevelObjective.Instance.IsComplete())
            {
                Debug.Log("Level exit");
                //todo
                //play animation
                //in the last frame of animation trigger NextScene
            }
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene(nextSceneId);
    }
}
