using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    Animator animator;
    ItemLife itemLife;
    bool deathTriggered = false;

    // Determines how long we wait before destorying the game object
    public int destroyTimer = 1;


    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        itemLife = gameObject.GetComponent<ItemLife>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Trigger the Death Animation
        if (itemLife.health <= 0 && !deathTriggered) {

            // Call the Death Animation
            animator.SetTrigger("Death");

            // Update the Death Trigger Boolean to stop looping
            deathTriggered = true;

            // Start a Timer to Destory the Game Object
            StartCoroutine(DestoryGameObject(destroyTimer));

        }
    }

    // Destory Timer - invoked with Couroutine in Update()
    IEnumerator DestoryGameObject(int timer) {
        // Wait before destorying
        yield return new WaitForSeconds(timer);
        // Destory myself
        Destroy(gameObject);
        
        //+1 enemy died
        PlayerInventory.Instance.enemiesDefeated++;
        LevelObjective.Instance.UpdateObjectiveState();

    }
}
