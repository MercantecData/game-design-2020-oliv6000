using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    public Text PlayerHP;
    public Text EnemiesCount;

    private float Health;
    private float Enemies;


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        string playerHP = PlayerHP.text;
        Health = float.Parse(playerHP);

        string CountEnemies = EnemiesCount.text;
        Enemies = float.Parse(CountEnemies);

        if (Health <= 0)
        {
            //SceneManager.LoadScene("1");

            UnityEngine.SceneManagement.SceneManager.LoadScene("DyingMenu");
        }
        else if (Enemies <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryMenu");
        }
    }
}
