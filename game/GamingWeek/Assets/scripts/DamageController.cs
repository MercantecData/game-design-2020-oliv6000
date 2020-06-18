using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageController : MonoBehaviour
{
    public Text PlayerHP;
    public Text BulletDMG;
    public GameObject Enemy;

    private float playerHP;
    private float bulletDMG;


    // Start is called before the first frame update
    void Start()
    {
        configPlayer();

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other);
        }
        Destroy(gameObject);




    }

    void configPlayer()
    {
        string PlayerHealth = PlayerHP.text;
        playerHP = float.Parse(PlayerHealth);


        string BulletDamage = BulletDMG.text;
        bulletDMG = float.Parse(BulletDamage);
    }
}
