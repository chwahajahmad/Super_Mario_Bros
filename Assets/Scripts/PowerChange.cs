
using UnityEngine;

public class PowerChange : MonoBehaviour
{
    private BoxCollider2D boxCol;
    private Animator animator;

    private void Start()
    {
        boxCol = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }
    public void changePower(int n)
    {
        if(n>=1 && n<=3)
        {
            if(n == 1)
            {
                Debug.Log("MOve to Power Level 1");
                animator.SetLayerWeight(animator.GetLayerIndex("Level1"), 1);
                animator.SetLayerWeight(animator.GetLayerIndex("Level2"), 0);
                animator.SetLayerWeight(animator.GetLayerIndex("Level3"), 0);
                boxCol.size = new Vector2(0.9285714f,1.142857f);
            }
            else if(n == 2)
            {
                Debug.Log("MOve to Power Level 2");
                animator.SetLayerWeight(animator.GetLayerIndex("Level1"), 0);
                animator.SetLayerWeight(animator.GetLayerIndex("Level2"), 1);
                animator.SetLayerWeight(animator.GetLayerIndex("Level3"), 0);
                boxCol.size = new Vector2(0.9285714f,2);
            }
            else if(n == 3)
            {
                animator.SetLayerWeight(animator.GetLayerIndex("Level1"), 0);
                animator.SetLayerWeight(animator.GetLayerIndex("Level2"), 0);
                animator.SetLayerWeight(animator.GetLayerIndex("Level3"), 1);
                boxCol.size = new Vector2(0.9285714f,2);
            }
        }
    }
}
