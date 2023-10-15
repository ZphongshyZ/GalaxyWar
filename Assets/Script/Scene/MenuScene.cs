using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScene : SceneManager
{
    public void PlayGame()
    {
        WinScene.Instance.IsWinning = false;
        Time.timeScale = 1f;
        this.GotoScene("PlayScene");
    }

    public void HighScore()
    {
        this.GotoScene("HighScoreScene");
    }
}
