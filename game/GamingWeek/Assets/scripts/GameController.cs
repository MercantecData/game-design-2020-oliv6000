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
    



    public Transform HealthPlaceholder;
    public Transform BulletPlaceholder;
    public Transform AmountOfEnemies;

    private string playerHP;
    private string bulletsInGun;
    private float Ammo;
    private float Health;

    public void Awake()
    {
        // This is for showing the amount of remaining bullets in the gun

        // This is for showing the players hp
    }

    public void Update()
    {
        playerHP = PlayerHP.text;
        Health = float.Parse(playerHP);
        HealthPlaceholder.GetComponent<Text>().text = "" + Health;

            bulletsInGun = BulletsInGun.text;
            Ammo = float.Parse(bulletsInGun);


        float Enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        AmountOfEnemies.GetComponent<Text>().text = "" + Enemies;

        HealthPlaceholder.GetComponent<Text>().text = "" + Health;

        BulletPlaceholder.GetComponent<Text>().text = "" + Ammo;
        if (Input.GetButtonDown("Fire1") && Ammo > 0)
        {
            Ammo -= 1;
            BulletsInGun.GetComponent<Text>().text = "" + Ammo;
        }
        else if (Ammo == 0)
        {
            BulletPlaceholder.GetComponent<Text>().text = "Out of ammo!";
        }

    }
}