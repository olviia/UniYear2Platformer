using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{

    
    public AudioSource chasingAudio;
    public AudioSource attackAudio;
    public AudioSource deathAudio;

    void Start(){
    }

    public void PlayChasingAudio(bool chasing){
        if(chasing && !chasingAudio.isPlaying){
            chasingAudio.Play();
        }
        if (!chasing){
            chasingAudio.Stop();
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
}