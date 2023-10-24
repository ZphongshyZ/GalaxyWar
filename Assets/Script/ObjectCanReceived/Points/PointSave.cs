using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointSave : SceneManager
{
    //Singleton
    protected static PointSave instance;
    public static PointSave Instance { get => instance; }

    //Gameobj
    [SerializeField] protected TextMeshProUGUI textSaveSocre;
    [SerializeField] protected TMP_InputField inputSaveName;

    //Properties
    [SerializeField] protected string saveName;
    public string SaveName => saveName;

    [SerializeField] protected int saveScore;
    public int SaveScore => saveScore;

    protected override void Awake()
    {
        base.Awake();
        if (PointSave.instance != null) Debug.Log("Only 1 PointSave allowed to exist");
        PointSave.instance = this;
    }

    //PointSave
    protected override void Start()
    {
        base.Start();
        this.textSaveSocre.text = "Score: " + PointManager.Instance.point.ToString();
    }

    public virtual void Save()
    {
        this.saveName = this.inputSaveName.text;
        this.saveScore = PointManager.Instance.point;
        this.GotoMainMenu();
    }
}
