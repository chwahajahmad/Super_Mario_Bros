
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 dimensions;
    
    private bool reachedEnd;
    void Start()
    {
        reachedEnd = false;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Flag")
        {
            reachedEnd = true;
        }
    }
    
    public bool getReachedEnd()
    {
        return reachedEnd;
    }
}
