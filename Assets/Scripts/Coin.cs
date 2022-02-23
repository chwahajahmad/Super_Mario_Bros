using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        anim.SetTrigger("giveCoin");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, 1.2f);
    }
}
