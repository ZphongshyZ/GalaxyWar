using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseScene : SceneManager
{
    protected static LoseScene instance;
    public static LoseScene Instance { get => instance; }

    [SerializeField] protected bool isLossing = false;
    public bool IsLossing { get => isLossing; set => isLossing = value; }

    [SerializeField] protected GameObject loseScene;
    [SerializeField] protected TextMeshProUGUI scoreText;

    protected override void Awake()
    {
        base.Awake();
        if (LoseScene.instance != null) Debug.Log("Only 1 LoseScene allowed to exist");
        LoseScene.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.loseScene.SetActive(false);
    }

    private void Update()
    {
        this.UpdateScore();
        if (this.isLossing == true) Invoke("Lose", 3f);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLoseScene();
    }

    protected virtual void LoadLoseScene()
    {
        this.loseScene = GameObject.Find("LoseScene");
    }

    protected virtual void Lose()
    {
        this.loseScene.SetActive(true);
    }

    protected virtual void UpdateScore()
    {
        this.scoreText.text = "Score: " + PointManager.Instance.point.ToString();
    }

    public virtual void Restart()
    {
        this.GotoScene("PlayScene");
    }

    public virtual void Continues()
    {
        this.GotoMainMenu();
    }
}
