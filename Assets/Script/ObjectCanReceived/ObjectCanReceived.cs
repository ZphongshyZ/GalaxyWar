using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCanReceived : PhongMonobehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected int maxReceived;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        this.player = GameObject.Find("Ship");
    }

    public virtual void AdddObj()
    {
        if (!this.CanAddObj()) return;
        this.Upggrade();
    }

    public virtual bool CanAddObj()
    {
        return true;
    }

    public virtual void Upggrade()
    {

    }
}
