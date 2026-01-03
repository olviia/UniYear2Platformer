using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public GameObject nextScenePopup;

    private void Start()
    {
        nextScenePopup.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (LevelObjective.Instance.IsComplete())
            {
                Debug.Log("Level exit");
                //todo
                //play animation
                nextScenePopup.SetActive(true);
            }
        }
    }
}
