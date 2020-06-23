using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public GameObject Player;
    public Text PlayerHP;

    public Text BulletsInGun;


    public static float Bullets;
    public static float Health;

    public Transform HealthPlaceholder;
    public Transform BulletPlaceholder;
    public Transform AmountOfEnemies;

    private string playerHP;

    public void Awake()
    {
        // This is for showing the amount of remaining bullets in the gun
        string bulletsGun = BulletsInGun.text;
        Bullets = float.Parse(bulletsGun);
        BulletPlaceholder.GetComponent<Text>().text = Bullets.ToString();

        // This is for showing the players hp
        playerHP = PlayerHP.text;
        Health = float.Parse(playerHP);
        HealthPlaceholder.GetComponent<Text>().text = "" + Health;
    }

    public void Update()
    {
        float Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        AmountOfEnemies.GetComponent<Text>().text = "" + Enemies;

        HealthPlaceholder.GetComponent<Text>().text = "" + Health;

        if (Input.GetButtonDown("Fire1") && Bullets > 0)
        {
            Bullets -= 1;
            BulletPlaceholder.GetComponent<Text>().text = Bullets.ToString();
            Health -= 10;

        }
        else if (Bullets == 0)
        {
            BulletPlaceholder.GetComponent<Text>().text = "Bullets: Out of ammo!";
        }

    }
}