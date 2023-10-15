using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : SceneManager
{
    protected static WinScene instance;
    public static WinScene Instance { get => instance; }

    [SerializeField] protected GameObject winScene;
    [SerializeField] protected TextMeshProUGUI scoreText;

    [SerializeField] protected bool isWinning = false;
    public bool IsWinning { get => isWinning; set => isWinning = value; }

    protected override void Start()
    {
        base.Start();
        this.winScene.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWinScene();
    }

    protected override void Awake()
    {
        base.Awake();
        if (WinScene.instance != null) Debug.Log("Only 1 WinScene allowed to exist");
        WinScene.instance = this;
        this.scoreText.fontSize = 50;
    }

    protected virtual void LoadWinScene()
    {
        this.winScene = GameObject.Find("WinScene");
    }

    private void Update()
    {
        this.UpdateScore();
        if (this.isWinning == true) Invoke("Win", 5f);
    }

    protected virtual void Win()
    {
        this.winScene.SetActive(true);
    }

    protected virtual void UpdateScore()
    {
        this.scoreText.text = "Score: " + PointManager.Instance.point.ToString();
    }

    public virtual void Continues()
    {
        this.GotoMainMenu();
    }    
}
