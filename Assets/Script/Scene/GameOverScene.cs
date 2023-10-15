using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScene : SceneManager
{
    //Singleton
    protected static GameOverScene instance;
    public static GameOverScene Instance { get => instance; }

    [Header("===WinScene===")]
    [SerializeField] protected GameObject winScene;
    [SerializeField] protected TextMeshProUGUI winScoreText;
    [SerializeField] protected bool isWinning = false;
    public bool IsWinning { get => isWinning; set => isWinning = value; }

    [Header("===LoseScene===")]
    [SerializeField] protected GameObject loseScene;
    [SerializeField] protected TextMeshProUGUI loseScoreText;
    [SerializeField] protected bool isLossing = false;
    public bool IsLossing { get => isLossing; set => isLossing = value; }

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadScene();
    }

    protected virtual void LoadScene()
    {
        this.winScene = GameObject.Find("WinScene");
        this.loseScene = GameObject.Find("LoseScene");
    }

    //GameOverScene
    protected override void Awake()
    {
        base.Awake();
        if (GameOverScene.instance != null) Debug.Log("Only 1 GameOverScene allowed to exist");
        GameOverScene.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.winScene.SetActive(false);
        this.loseScene.SetActive(false);
    }

    private void Update()
    {
        this.UpdateScore();
        if (this.isWinning == true) Invoke("Win", 5f);
        if (this.isLossing == true) Invoke("Lose", 3f);
        if (this.isWinning == true && this.isLossing == true) Invoke("Win", 5f);
    }

    protected virtual void Win()
    {
        this.winScene.SetActive(true);
    }

    protected virtual void Lose()
    {
        this.loseScene.SetActive(true);
    }

    public virtual void Restart()
    {
        this.GotoScene("PlayScene");
    }

    protected virtual void UpdateScore()
    {
        this.winScoreText.text = "Score: " + PointManager.Instance.point.ToString();
        this.loseScoreText.text = "Score: " + PointManager.Instance.point.ToString();
    }

    public virtual void Continues()
    {
        this.GotoMainMenu();
    }
}
