using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Transform BulletsPlaceholder;
    public Text BulletsInGun;
    private float Ammo;

    public Text AmmoInCrate;
    private string ammoInCrate;
    private float AmmoCrateValue;

    public Text PlayerHP;
    private string playerHP;
    private float playerHealth;

    public Text EnemyDMG;
    private string enemyDMG;
    private float enemyDamage;

    private AudioSource audioSource;

    public float DMGCooldown = 1;
    private float Timer;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponentInChildren<AudioSource>();

        string bulletsInGun = BulletsInGun.text;
        Ammo = float.Parse(bulletsInGun);
        
        enemyDMG = EnemyDMG.text;
        enemyDamage = float.Parse(enemyDMG);

        playerHP = PlayerHP.text;
        playerHealth = float.Parse(playerHP);
    }

    // Update is called once per frame
    void Update()
    {

        string bulletsInGun = BulletsInGun.text;
        Ammo = float.Parse(bulletsInGun);


        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else if (Timer <= 0)
        {
            Timer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AmmoCrate"))
        {
            audioSource.Play();
            ammoInCrate = AmmoInCrate.text;
            AmmoCrateValue = float.Parse(ammoInCrate);

            Ammo += AmmoCrateValue;
            Destroy(other.gameObject);
            BulletsInGun.GetComponent<Text>().text = "" + Ammo;
        }

        // IT WORKS, BUT HEALTH DOES NOT GET SUBTRACTED NOR DOES THE TEXT UPDATE
        if (other.CompareTag("Enemy"))
        {
            if (Timer == 0)
            {
                playerHealth -= enemyDamage;
                PlayerHP.GetComponent<Text>().text = "" + playerHealth;
                Timer = DMGCooldown;
            }
        }
    }
}

