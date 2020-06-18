using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public Text AmountOfBullets;
    public Transform firePoint;
    public float bulletForce = 20f;

    public GameObject bulletPrefab;


    private float BulletCount;
    // Start is called before the first frame update
    void Start()
    {
        string bulletsInGun = AmountOfBullets.text;
        BulletCount = float.Parse(bulletsInGun);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }



    void Shoot()
    {

        if (BulletCount > 0)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

            Destroy(bullet, 2f);
            BulletCount -= 1;
        }
        else
        {
            print("You ain't got no more ammo");
        }
    }
}
