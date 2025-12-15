using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    // Coins Value
    public int coins = 0;
    
    // Reference the Collectables Audio Source 



    // Start is called before the first frame update
    void Start()
    {
        
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
            

            // Play the Audio file
            

            // Destory the collectable
            Destroy(collectable);

            // Debug the new Total
            Debug.Log("Player now has: " + coins + " Coins in their Inventory.");

        }
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
