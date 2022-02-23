using UnityEngine;

public class Power : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    float direction = -1;
    bool collidedOnce;
    bool startMoving;
    [SerializeField] int powerToAdd;
    void Start()
    {
        Debug.Log("Instantiated power");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        rb.AddForce(transform.up * 6, ForceMode2D.Impulse);
        
        //anim.SetTrigger("");
    }

    void Update()
    {
        if (startMoving)
        {
            if (direction == -1)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                rb.velocity = new Vector2(3, rb.velocity.y);
            }
            else if (direction == 1)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rb.velocity = new Vector2(-3, rb.velocity.y);

            }
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Pipes" || other.gameObject.tag == "Stairs")
        {
            Debug.Log("Power Object Should Change Direction Now");
            reverseDirection();
        }
        
        if (other.gameObject.tag == "Player")
        {
            GameObject.Find("Scoring").GetComponent<ScoringBook>().setPower(powerToAdd);
            Debug.Log("Add score 1000");
            GameObject.Find("Scoring").GetComponent<ScoringBook>().updateScore(1000);
            Destroy(this.gameObject);
        }
        
        if(other.gameObject.tag == "SurpriseTiles" && collidedOnce == true)
        {
            startMoving = true;
        }
        collidedOnce = true;
       
    }

 

    public void reverseDirection()
    {
        direction *= -1;
    }

    
}
