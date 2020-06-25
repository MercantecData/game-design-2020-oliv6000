using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    
        private string currentState = "Patrol";

        public float health = 5;
        public float damage = 5;
        public float moveSpeed = 5f;

        public float patrolSpeed = 5;
        public float attackSpeed = 8;
        public float range = 15;

        public Animator anime;  

        public LayerMask mask;

        public Text BulletDamage;
        public Transform waypoint1;
        public Transform waypoint2;

        private Transform nextWaypoint;
    

    public Transform player;
    private Rigidbody2D rb;
    private float bulletDMG;


    // Start is called before the first frame update
    void Start()
    {
        string BulletDMG = BulletDamage.text;
        bulletDMG = float.Parse(BulletDMG);

        nextWaypoint = waypoint1;
        rb = this.GetComponent<Rigidbody2D>();

        anime = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            // Destroys enemy
            Destroy(gameObject);
        }

        AquireTarget();

        if (currentState == "Patrol")
        {
            patrol();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            health -= bulletDMG;
            Destroy(other.gameObject);
            anime.Play("animation");
        }
    }

    bool patrol()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * patrolSpeed);
        transform.position = nextPosition;


        Vector3 direction = nextWaypoint.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;

        if (transform.position == nextWaypoint.position)
        {
            if (nextWaypoint == waypoint1)
            {
                nextWaypoint = waypoint2;
            }
            else
            {
                nextWaypoint = waypoint1;
            }
        }

        return true;
    }

    bool AquireTarget()
    {
        var targetLocation = player.position;

        bool inRange = false;
        bool inVision = false;
        bool tooClose = false;

        // Checks if enemy location is less than (range) and if so, move towards target. 
        if (Vector3.Distance(targetLocation, transform.position) < range)
        {
            inRange = true;
            tooClose = false;
        }

        if (Vector3.Distance(targetLocation, transform.position) < 0.9)
        {
            tooClose = true;
        }

        var linecast = Physics2D.Linecast(transform.position, player.position, mask);
        if (linecast.transform == null)
        {
            inVision = true;
            currentState = "Attack";
        }
        Attack(inRange, inVision, tooClose);
        return inRange && inVision;
    }

    bool Attack(bool inRange, bool inVision, bool tooClose)
    {
        if (inVision == true)
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }

        if (inRange == true && inVision == true && tooClose == false)
        {
            Vector3 targetLocation = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * attackSpeed);
            transform.position = targetLocation;




        }
        else if (tooClose == true)
        {
        }
        else
        {
            currentState = "Patrol";
        }



        return inRange;
    }
    

}
