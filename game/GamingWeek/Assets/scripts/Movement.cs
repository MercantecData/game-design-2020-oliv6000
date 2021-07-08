using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10;

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


        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);










    }
}
