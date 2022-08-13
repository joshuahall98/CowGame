using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;
    bool canFire = true;

    GameObject alien;

    private void Start()
    {
        alien = GameObject.Find("Alien");
    }

    public void Fire()
    {
        if(canFire == true)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);
            canFire = false;
            alien.GetComponent<Alien>().Angry();
        }
        
    }
}
