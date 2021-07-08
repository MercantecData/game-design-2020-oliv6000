using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class VictoryGamecontroller : MonoBehaviour
{
    public Button PlayAgain;
    public Button Quit;


    // Start is called before the first frame update
    void Start()
    {
        Button playAgain = PlayAgain.GetComponent<Button>();
        playAgain.onClick.AddListener(play);

        Button quit = Quit.GetComponent<Button>();
        quit.onClick.AddListener(quitGame);
    }

    void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TheGame");
    }

    void quitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
