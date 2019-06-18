using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;


    private float fire_speed = 0.2f;
    private float cooldown = 0f;
    void Start()
    {
        firePoint = GetComponent<Transform>();
    }

    void Update()
    {   
        cooldown -= Time.deltaTime;
        Debug.Log(cooldown);
        if (Input.GetButton("Fire1"))
        {
            if (cooldown <= 0f)
            {
                Shoot();

            }
            
        }
    }

    void Shoot()
    {
        
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        cooldown = fire_speed;
    }
}
