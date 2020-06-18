using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("bar");

        print(bar.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
