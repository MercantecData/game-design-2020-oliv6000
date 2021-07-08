using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Enemy;
    public GameObject EnemyLocation;
    public Sprite DeathSprite;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = EnemyLocation.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy == false)
        {
            anim.Play("EnemyDeath");
        }
    }


}
