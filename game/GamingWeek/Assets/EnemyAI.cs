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
    
    // Start is called before the first frame update
    void Start()
    {
        nextWaypoint = waypoint1;
    }

    // Update is called once per frame
    void Update()
    {
        AquireTarget();

        if (currentState == "Patrol")
        {
            patrol();
        }
    }


    bool patrol()
    {
        Vector3 nextPosition = Vector3.MoveTowards(transform.position, nextWaypoint.position, Time.deltaTime * patrolSpeed);
        transform.position = nextPosition;


        if (transform.position == nextWaypoint.position)
        {
            if (nextWaypoint == waypoint1)
            {
                transform.Rotate(Vector3.back * 180);
                nextWaypoint = waypoint2;
            }
            else
            {
                transform.Rotate(Vector3.forward * -180);
                nextWaypoint = waypoint1;
            }
        }

        return true;
    }

    bool AquireTarget()
    {
        GameObject targetGO = GameObject.FindGameObjectWithTag("Player");
        
        
        var targetLocation = targetGO.transform.position;

        bool inRange = false;
        bool inVision = false;

        if (Vector3.Distance(targetLocation, transform.position) < range)
        {
            inRange = true;
        }

        var linecast = Physics2D.Linecast(transform.position, targetGO.transform.position, mask);
        if (linecast.transform == null)
        {
            inVision = true;
            currentState = "Attack";
        }
        Attack(inRange, inVision, targetGO);
        return inRange && inVision;
    }

    bool Attack(bool inRange, bool inVision, GameObject target)
    {
        if (inRange == true && inVision == true)
        {
            Vector3 targetGO = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * attackSpeed);
            transform.position = targetGO;
        }
        else
        {
            currentState = "Patrol";
        }



        return inRange;
    }

}
