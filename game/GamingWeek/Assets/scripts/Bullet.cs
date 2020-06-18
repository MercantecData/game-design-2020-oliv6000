using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);
        Destroy(gameObject);


        if (other.CompareTag("Enemy"))
        {

            Destroy(other.gameObject);
            Destroy(gameObject);

        }
    }
}
