using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset.z = -10f;
    }

    void FixedUpdate()
    {
        //this.transform.position = new Vector3(followTransform.position.x, followTransform.position.y, this.transform.position.z);

        //Vector3 playerPosition = Vector3.MoveTowards(this.transform.position, player.position.x, player.position.y, Time.deltaTime * 6f);

        Vector3 Player = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, Player, smoothSpeed);

        this.transform.position = smoothedPosition;
    }
}
