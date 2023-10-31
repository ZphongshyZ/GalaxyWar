using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldOfShip : PhongMonobehaviour
{
    //Singleton
    protected static ShieldOfShip instance;
    public static ShieldOfShip Instance { get => instance; }

    //Obj
    [SerializeField] protected GameObject shield;

    //Properties
    [SerializeField] protected bool isProtected = false;
    public bool IsProtected { get => isProtected; }

    [SerializeField] protected float timeShield = 5f;
    [SerializeField] protected float time = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (ShieldOfShip.instance != null) Debug.Log("Only 1 ShieldOfShip allowed to exist");
        ShieldOfShip.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShield();
    }

    //Protected
    protected virtual void LoadShield()
    {
        this.shield = GameObject.Find("Sheild");
    }

    protected override void Start()
    {
        base.Start();
        this.shield.SetActive(false);
    }

    protected virtual void Update()
    {
        this.TurnOfShield();
    }

    public virtual void TurnOnShield()
    {
        this.isProtected = true;
        this.shield?.SetActive(true);
    }

    public virtual void TurnOfShield()
    {
        if (this.isProtected == false) return;
        this.time += Time.deltaTime;
        if (this.time < this.timeShield) return;
        this.time = 0;
        this.isProtected = false;
        this.shield?.SetActive(false);
    }
}
