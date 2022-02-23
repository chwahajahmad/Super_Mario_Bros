
using System;
using UnityEngine;

public class GiveSurprise : MonoBehaviour
{
    Animator anim;

    private void Start()
    {
         anim = GetComponent<Animator>();
    }
    public void ShootSurprise(Transform trans,GameObject surprise)
    {
        
        Instantiate(surprise,new Vector3(trans.position.x,trans.position.y+1,0) , trans.rotation);
    }
}
