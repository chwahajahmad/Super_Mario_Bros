
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpForce;

    private Rigidbody2D rb;
    private Animator anim;
    private float horizontal;
    bool IsColiding = true;
    bool isDead = false;
    private bool reachedEnd;

    public Transform cam;
    public bool getIsDead()
    {
        return isDead;
    }

    void Start()
    {
        reachedEnd = GetComponent<PlayerCollision>().getReachedEnd();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = GameObject.Find("MainCamera").GetComponent<Transform>();
    }
    private void Update()
    {

        if(!reachedEnd && !isDead)
        {
            if (Input.GetKeyDown(KeyCode.Space) && IsColiding == true)
            {
                IsColiding = false;
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                anim.SetBool("isJumping", true);
                GameObject.Find("VFXSoundManager").GetComponent<VFXSOUNDMANAGER>().PlaySound("jump");
            }
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("isShooting");
            }
            if (transform.position.y < -3)
            {
               
                playerDeath();
                GameObject.Find("Scoring").GetComponent<ScoringBook>().decreaseHealth(1);
            }
        }
   
    }



    private void FixedUpdate()
    {
        reachedEnd = GetComponent<PlayerCollision>().getReachedEnd();
        if(!reachedEnd && !isDead)
        {
            anim.SetBool("Walk", true);
            horizontal = Input.GetAxis("Horizontal");
            if (horizontal > 0.01)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else if (horizontal < -0.01)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                if(transform.position.x <  cam.position.x - 13)
                    horizontal = 0;

                
            }
            else
            {
                anim.SetBool("Walk", false);
            }
            float moveX = horizontal * 10 * Time.deltaTime * movementSpeed;
            rb.velocity = new Vector2(moveX, rb.velocity.y);
            
        }
        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("SimpleTiles") || collision.gameObject.CompareTag("SurpriseTiles") ||
            collision.gameObject.CompareTag("Stairs") || collision.gameObject.CompareTag("Pipes"))
        {
            anim.SetBool("isJumping", false);
            IsColiding = true;
        }
    }

    public void playerDeath()
    {
        Debug.Log("death animation call");
        anim.SetBool("isDeath", true);
        GameObject.Find("VFXSoundManager").GetComponent<VFXSOUNDMANAGER>().PlaySound("death");
        isDead = true;
        StartCoroutine("isDeathAnimation");
      
    }
    IEnumerator isDeathAnimation()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
        anim.SetBool("isDeath", false);
    }
}
