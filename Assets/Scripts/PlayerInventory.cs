using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance{get; private set;}
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }
    
    
    // Coins Value
    public int coins = 0;
    public int enemiesDefeated = 0;
    public int keys = 0;
    
    // Reference the Collectables Audio Source 
private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        GameObject childCollectableAudio = new GameObject("childCollectableAudio");
        childCollectableAudio.transform.SetParent(transform);
        audioSource = childCollectableAudio.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Is the player colliding with a collectable? 
        if (collision.collider.tag == "Collectables")
        {
            // Create a reference to the collectable
            GameObject collectable = collision.gameObject;

            // Report the Collectable name 
            Debug.Log("Collided with a Collectable: " + collectable.name);
            
            // Get the Item Value Scripts - Value Variable
            int collectableValue = collectable.GetComponent<ItemValue>().value;
            
            // Update the Coins total
            coins += collectableValue;

            // Load the Audio file to the Audio Source
            audioSource.clip = collectable.GetComponent<ItemAudio>().audioFile;

            // Play the Audio file
            audioSource.Play();

            // Destory the collectable
            Destroy(collectable);

            // Debug the new Total
            Debug.Log("Player now has: " + coins + " Coins in their Inventory.");

        }
        LevelObjective.Instance.UpdateObjectiveState();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // Is the player colliding with a collectable? 
        if (collision.collider.tag == "Collectables")
        {
            Debug.Log("Stopped colliding with the Collectable: " + collision.collider.name);
        }

    }




}
