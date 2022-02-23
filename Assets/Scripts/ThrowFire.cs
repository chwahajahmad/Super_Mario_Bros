using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowFire : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
  
    [SerializeField] float timeInterval;
    private float timePassed = 0f;
  
    void Update()
    {   
        if (timePassed >= timeInterval && Mathf.Abs(GameObject.Find("Player").GetComponent<Transform>().position.x - transform.position.x) < 7 )
        {
            Shoot();
            timePassed = 0f;
        }
    }

    void FixedUpdate()
    {
        timePassed += 0.02f;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
