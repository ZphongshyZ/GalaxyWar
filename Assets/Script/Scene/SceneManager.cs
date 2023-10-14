using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : PhongMonobehaviour
{
    public void GotoScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
        Debug.Log("Go to " + nameScene);
    }

    public virtual void GotoMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
