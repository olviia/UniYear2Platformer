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
                other.gameObject.GetComponent<PlayerManager>().stopMovement();
                
                //todo
                //play final animation
                
                nextScenePopup.SetActive(true);
            }
            else
            {
                //todo
                //maybe play some other animation, and turn it off on trigger exit
            }
        }
    }
}
