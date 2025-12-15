using UnityEngine;
using System.Collections.Generic;

public class PlayerAudioController : MonoBehaviour
{
    
public AudioClip[] list;
private AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayWalkingAudio(bool walking)
    {
        if (walking && (source.clip == list[0] && !source.isPlaying || source.clip != list[0]))
        {
	source.clip = list[0];
            source.Play();
        }
        if (!walking)
        {
            source.Stop();
        }

    }
    public void PlayAttackAudio()
    {
	source.clip = list[0];
        source.Play();
    }
}
