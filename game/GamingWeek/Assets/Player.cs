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

    // Start is called before the first frame update
    void Start()
    {
        print(BulletsInGun);
        string bulletsInGun = BulletsInGun.text;
        Ammo = float.Parse(bulletsInGun);
    }

    // Update is called once per frame
    void Update()
    {
            string bulletsInGun = BulletsInGun.text;
            Ammo = float.Parse(bulletsInGun);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        if (other.CompareTag("AmmoCrate"))
        {
            ammoInCrate = AmmoInCrate.text;
            AmmoCrateValue = float.Parse(ammoInCrate);

            Ammo += AmmoCrateValue;
            Destroy(other.gameObject);
            BulletsInGun.GetComponent<Text>().text = "" + Ammo;
            
            //health -= bulletDMG;
            //Destroy(other.gameObject);
            //anime.Play("animation");
        }
    }
}
