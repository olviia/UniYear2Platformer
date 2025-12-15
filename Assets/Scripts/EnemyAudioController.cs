using UnityEngine;

public class EnemyAudioController : MonoBehaviour
{

    
public AudioSource chasingAudio;

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
}
