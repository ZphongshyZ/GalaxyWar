using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScene : SceneManager
{
    //GameObj
    [SerializeField] protected GameObject pauseMenu;
    
    //Properties
    public bool isPaused;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPauseScene();
    }

    protected virtual void LoadPauseScene()
    {
        this.pauseMenu = GameObject.Find("PauseScene");
    }

    //PauseScene
    protected override void Start()
    {
        base.Start();
        pauseMenu.SetActive(false);
    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public override void GotoMainMenu()
    {
        Time.timeScale = 1f;
        base.GotoMainMenu();
    }
}
