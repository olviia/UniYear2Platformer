using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{
    public int toSceneId;

    public void Go()
    {

        StartCoroutine(PlayAudio());
    }

    public IEnumerator PlayAudio()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
            
        
        audioSource.Play();
        

        //wait until sound is played
        yield return new WaitForSeconds(audioSource.clip.length);
        
        SceneManager.LoadScene(toSceneId);
    }
}
