using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class TheGameSceneController : MonoBehaviour
{
    


    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("TheGame");
        }
    }
}
