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
    [SerializeField] protected GameObject ship;

    //Properties
    [SerializeField] protected bool isShielding = false;
    public bool IsShielding { get => isShielding; set => isShielding = value; }

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

    protected virtual void LoadShield()
    {
        this.shield = GameObject.Find("Shield");
        this.ship = transform.parent.GetComponentInChildren<ShipDamageReiceiver>().gameObject;
    }

    protected override void Start()
    {
        base.Start();
        this.shield.SetActive(isShielding);
    }

    private void Update()
    {
        this.shield.SetActive(this.isShielding);
        this.ship.SetActive(!this.isShielding);
        this.TurnOfShield();
    }

    public virtual void TurnOfShield()
    {
        if (this.isShielding == false) return;
        this.time += Time.deltaTime;
        if (this.time < this.timeShield) return;
        this.time = 0;
        this.isShielding = false;
    }
}
