using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public Transform firepoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public static bool  IsShooting = true;


    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && IsShooting == true)
        {
           ShootBullets();
            
        }
        
        }

    void ShootBullets()
    {
        FindObjectOfType<AudioManager>().Play("Pew");
        GameObject bullet = Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 2f);
        
    }
}

    
    

