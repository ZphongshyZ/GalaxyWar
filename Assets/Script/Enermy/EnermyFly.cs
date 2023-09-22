using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyFly : ObjectCanFly
{
    [SerializeField] protected Transform zonePlayer;

    [SerializeField] protected float attackDis = 4f;
    protected float currentDis;

    protected override void Update()
    {
        base.Update();
        this.GetDistance();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipPlayer();
    }

    protected virtual void LoadShipPlayer()
    {
        this.zonePlayer = GameObject.Find("Zone").transform;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 1f;
        this.direction = Vector3.down;
    }

    protected virtual void GetDistance()
    {
        this.currentDis = transform.position.y - this.zonePlayer.position.y;
    }
}
