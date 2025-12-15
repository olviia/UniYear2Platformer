using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int coins = 0;
    public AudioSource collectablesAudioPlayer = new AudioSource();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Collectables")
        {
            GameObject collectable = collision.gameObject;
            int collectableValue = collectable.GetComponent<ItemValue>().value;
            coins += collectableValue;

            //play audio
            //why don't we play clip directly on the coin, why do we assign clip to other audio souce and then play it? 
            collectablesAudioPlayer.clip = collectable.GetComponent<ItemAudio>().audioFile;
            collectablesAudioPlayer.Play();

            Destroy(collectable);
            Debug.Log("current coins number " + coins);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
    }
}