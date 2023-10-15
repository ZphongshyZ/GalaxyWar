using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : SceneManager
{
    public void PlayGame()
    {
        this.GotoScene("PlayScene");
    }

    public void HighScore()
    {
        this.GotoScene("HighScoreScene");
    }
}
