using UnityEngine;

public class EnemyAgroZone : MonoBehaviour
{
    public GameObject target;
    public GameObject enemy;
    public float movementSpeed;
public EnemyAudioController enemyAudio;
    

    private Rigidbody2D enemyRigidBody;
    private Vector2 calculateDirection;
    private bool targetDetected;
    private Animator animator;
    private SpriteRenderer enemySR;

    void Start(){
        enemyRigidBody = enemy.GetComponent<Rigidbody2D>();
        enemySR = enemy.GetComponent<SpriteRenderer>();
        animator = enemy.GetComponent<Animator>();
    }

    private void FixedUpdate(){
        if(targetDetected){
            calculateDirection = (target.transform.position - enemy.transform.position).normalized;
            enemyRigidBody.linearVelocity = calculateDirection * movementSpeed;
        }
        else {
            enemyRigidBody.linearVelocity = new Vector2(0,0);
        }
    }
    private void Update(){
       
        animator.SetBool("Walking", targetDetected);
	enemyAudio.PlayChasingAudio(animator.GetBool("Walking"));
    
    if (enemyRigidBody.linearVelocity.x > 0)
        enemySR.flipX = false;
    else if (enemyRigidBody.linearVelocity.x < 0)
        enemySR.flipX = true;
    }

   private void OnTriggerEnter2D(Collider2D collision){
        if(collision.name.Equals(target.name)){
            targetDetected = true;
        }
   }
   private void OnTriggerExit2D(Collider2D collision){
       if(collision != null && collision.name.Equals(target.name)){
            targetDetected = false;
        }
   }
}
