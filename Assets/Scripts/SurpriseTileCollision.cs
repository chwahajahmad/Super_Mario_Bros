using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseTileCollision : MonoBehaviour
{
    Animator anim;
    bool check = true;
    [SerializeField] GameObject objectPrefab;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && check)
        {
            check = false;
            Debug.Log(objectPrefab.tag);
            Debug.Log("Player hits with tile" + transform.position);
            GameObject.Find("SurpriseTiles").GetComponent<GiveSurprise>().ShootSurprise(transform, objectPrefab);
            if (objectPrefab.tag == "Coin")
            {
                Debug.Log("Add score 200");
                GameObject.Find("Scoring").GetComponent<ScoringBook>().updateScore(200);
            }
            anim.SetTrigger("isHit");
            //Debug.Log("animation calls");
        }
    }
}
