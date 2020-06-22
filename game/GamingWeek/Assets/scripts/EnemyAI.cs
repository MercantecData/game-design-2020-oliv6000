using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    
        private string currentState = "Patrol";


        public float patrolSpeed = 5;
        public float attackSpeed = 8;

        public float range = 15;

        public LayerMask mask;

        public Transform waypoint1;
        public Transform waypoint2;

        private Transform nextWaypoint;
    

    //Video controll
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 direction = player.position - transform.position;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;
        //direction.Normalize();
        //movement = direction;

        AquireTarget();

        if (currentState == "Patrol")
        {
            patrol();
        }
        
    }
    
    bool patrol()
    {

        //Vector3 rot = transform.eulerAngles;
        //rot.z = nextWaypoint.transform.eulerAngles.z;
        //transform.eulerAngles = rot;
        //print("hmmmmm");

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

        if (Vector3.Distance(targetLocation, transform.position) < 1.2)
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
