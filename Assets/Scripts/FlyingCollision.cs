using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingCollision : MonoBehaviour
{
    
    [SerializeField] float deathWait;
    [SerializeField] Vector2 dimensionsAfterDeath;
    private CapsuleCollider2D col;
    void Start()
    {
        col = GetComponent<CapsuleCollider2D>();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Bullet")
            GetComponent<EnemyRecord>().decHealth();
         if (GetComponent<EnemyRecord>().getIsDead())
        {
            GameObject.Find("Scoring").GetComponent<ScoringBook>().updateScore(GetComponent<EnemyRecord>().getRewardForPlayer());
            
            col.size = dimensionsAfterDeath;
            Destroy(this.gameObject, deathWait);
        }
    }
}
