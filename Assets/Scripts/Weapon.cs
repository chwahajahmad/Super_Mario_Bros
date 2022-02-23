using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    [SerializeField] int minPowerToShoot;

    private int powerLevel;
    void Update()
    {   powerLevel = GameObject.Find("Scoring").GetComponent<ScoringBook>().getPower();
        if (Input.GetButtonDown("Fire1") && powerLevel >= minPowerToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
