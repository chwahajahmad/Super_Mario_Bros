

using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float movementSpeed;
    [SerializeField] int startMovementParam;
    float direction = -1;

    Rigidbody2D rb;
    Transform player;
    bool collidedOnce;

    bool isDead;
    bool startMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Transform>();
        collidedOnce = false;

        startMoving = false;
    }

    // Update is called once per frame



    void Update()
    {
        isDead = GetComponent<EnemyRecord>().getIsDead();

        if (transform.position.x - player.position.x < startMovementParam)
        {
        
            startMoving = true;
        }


        if (startMoving)
        {
            if (!isDead)
            {
                if (direction == -1)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                    rb.velocity = new Vector2(-movementSpeed, rb.velocity.y);
                }
                else if (direction == 1)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                    rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

                }
            }
        }
    }

    public void reverseDirection()
    {
        direction *= -1;
    }
}
