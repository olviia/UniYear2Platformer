using UnityEngine;
using System.Collections.Generic;

public class PlayerAudioController : MonoBehaviour
{
    public AudioSource walkingAudio;
    public AudioSource attackAudio;
    public AudioSource deathAudio;
    public AudioSource jumpAudio;

    void Start(){
    }

    public void PlayWalkingAudio(bool walking){
        if(walking && !walkingAudio.isPlaying){
            walkingAudio.Play();
        }
        if (!walking){
            walkingAudio.Stop();
        }
    }

    public void PlayAttackAudio()
    {
        attackAudio.Play();
    }
    public void PlayDeathAudio()
    {
        deathAudio.Play();
    }
    public void PlayJumpAudio()
    {
        jumpAudio.Play();
    }
}
