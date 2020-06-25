using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using JetBrains.Annotations;

public class SceneManager : MonoBehaviour
{
    public Text PlayerHP;
    public Text EnemiesCount;
    public Text VictoryText;
    public Text AditionalVictoryText;
    public bool Quit;

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

        if(Enemies <= 0)
        {
            VictoryText.text = "Victory";
            AditionalVictoryText.text = "Press enter to continue";
        }

        if (Input.GetKeyDown("return") && Enemies <= 0)
        {
            Quit = true;
        }

        if (Enemies <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("VictoryMenu");
        }

        if (Health <= 0)
        {
            //SceneManager.LoadScene("1");

            UnityEngine.SceneManagement.SceneManager.LoadScene("DyingMenu");
        }
    }
}
