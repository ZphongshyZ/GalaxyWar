using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class PointManager : PhongMonobehaviour
{
    //Singleton
    protected static PointManager instance;
    public static PointManager Instance { get => instance; }

    //GameObj
    [SerializeField] protected Text pointText;
    public Text PointText => pointText;

    //Properties
    public int point = 0;

    //PointManager System
    protected override void Awake()
    {
        base.Awake();
        if (PointManager.instance != null) Debug.Log("Only 1 PointManager allowed to exist");
        PointManager.instance = this;
        this.pointText.fontSize = 20;
    }

    private void Update()
    {
        this.UpdatePoint();
    }

    public virtual void AddPoint(int point)
    {
        this.point += point;
    }

    public virtual void UpdatePoint()
    {
        this.pointText.text = this.point.ToString();
    }
}
