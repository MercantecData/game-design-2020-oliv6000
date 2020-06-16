using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;
    public float speed2 = 5f;

    private Rigidbody2D rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //way to debug is --->>>AKA print()  example --> print(Input.GetAxis("Horizontal"));

        var horiInput = Input.GetAxis("Horizontal");
        var vertiInput = Input.GetAxis("Vertical");

        Vector2 position = transform.position;
        position.x += speed * Time.deltaTime * horiInput;
        position.y += speed * Time.deltaTime * vertiInput;
        //This does not take into account, that you might be hidding terrain, so it will bumb continuesly if this is used -> transform.position = position;
        rigidbody.MovePosition(position);


        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed2 * Time.deltaTime);



        if (Input.GetKey("w") || Input.GetKey("up"))
        {
            print("UP");
        }

        if (Input.GetKey("s") || Input.GetKey("down"))
        {
            print("DOWN");
        }








    }
}
