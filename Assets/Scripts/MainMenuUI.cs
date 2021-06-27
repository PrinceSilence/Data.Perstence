using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

[DefaultExecutionOrder(1000)] // makes the script load last
public class MainMenuUI : MonoBehaviour
{
    public Text playerName;
    public Text highScoreText;

    public string highScoreVaule;
    public string highScoreName;
    private void Start()
    {
        highScoreVaule = SaveManager.instatance.highScore.ToString();
        highScoreName = SaveManager.instatance.playerName;

        if (SaveManager.instatance.highScore == 0)
        {
            highScoreText.text = "No High Score :(";
        }
        else if(SaveManager.instatance.highScore > 0)
        {
            highScoreText.text = highScoreName + " : " + highScoreVaule;
        }

    }
    public void StartGame()
    {
        SaveManager.instatance.playerName = playerName.text;
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();

    }

}
