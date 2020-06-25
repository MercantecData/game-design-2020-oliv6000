using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDeath : MonoBehaviour
{
    public GameObject Enemy;
    public Animator anim;

    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
        

    // Update is called once per frame
    void Update()
    {
        if (Enemy == true)
        {
            Vector3 enemyLocation = Vector3.MoveTowards(transform.position, Enemy.transform.position, Time.deltaTime * 2000);
            transform.position = enemyLocation;
        }

        if (Enemy == false && i <= 0 )
        {
            i += 1;
            anim.Play("EnemyDead");
        }
    }
}
