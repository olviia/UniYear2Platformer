using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackRadius : MonoBehaviour
{
    // State the Attack Damage
    public int attackDamage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Are we attacking them Mobs?
        if (collision.gameObject.tag == "Mobs") {

            // get a temp reference to the item life
            ItemLife itemLife = collision.gameObject.GetComponent<ItemLife>();

            // Call the Hit to effect the colliding object HP 
            itemLife.Hit(attackDamage);
        
        }
    }
}
