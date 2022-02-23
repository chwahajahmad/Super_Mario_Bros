
using UnityEngine;

public class EnemyCollisionEffects : MonoBehaviour
{

    Animator anim;

    [SerializeField] float deathWait;
    [SerializeField] Vector2 dimensionsAfterDeath;
    private CapsuleCollider2D col;
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider2D>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
            GetComponent<EnemyRecord>().decHealth();
        if(other.gameObject.tag == "Player")    
            GetComponent<EnemyRecord>().setIsDead(true);
        if (GetComponent<EnemyRecord>().getIsDead())
        {
            GameObject.Find("Scoring").GetComponent<ScoringBook>().updateScore(GetComponent<EnemyRecord>().getRewardForPlayer());
            anim.SetBool("dead", true);
            col.size = dimensionsAfterDeath;
            Destroy(this.gameObject, deathWait);
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (!GetComponent<EnemyRecord>().getIsDead() && !GameObject.Find("Player").GetComponent<PlayerMovement>().getIsDead())
                GameObject.Find("Scoring").GetComponent<ScoringBook>().decreaseHealth(GetComponent<EnemyRecord>().getDamage());
        }
        else if (other.gameObject.tag == "Pipes")
        {
            Debug.Log("Enemy Should Change Direction Now");
            GetComponent<EnemyMovement>().reverseDirection();
        }
    }
  
}
