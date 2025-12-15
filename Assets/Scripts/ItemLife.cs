using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLife : MonoBehaviour
{
    // Set the default HP to 100
    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int damage)
    {
        // If the Game object has a HP greater than zero
        if (health > 0) {

            // Remove the damage supplied when the hit is called
            health = health - damage;

            // Debug
            Debug.Log(gameObject.name + " - HP: " + health);
        
        } 
    }
}
