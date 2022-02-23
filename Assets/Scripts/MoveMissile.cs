using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMissile : MonoBehaviour
{
   [SerializeField] float speed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }

    void Update()
    {
        Destroy(this.gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            if(!other.gameObject.GetComponent<PlayerMovement>().getIsDead())
                GameObject.Find("Scoring").GetComponent<ScoringBook>().decreaseHealth(GameObject.Find("FlyingEnemy").GetComponent<EnemyRecord>().getDamage());
            Destroy(this.gameObject);
        }
    }
}
