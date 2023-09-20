using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_2 : EnermyFly
{
    [SerializeField] protected EnermyShooting enermyShooting;
    [SerializeField] protected float attackDis = 4.5f;

    protected override void Update()
    {
        base.Update();
        this.Chase();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyShooting();
    }

    protected virtual void LoadEnermyShooting()
    {
        this.enermyShooting = transform.parent.GetComponentInChildren<EnermyShooting>();
    }

    protected virtual void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.enermyShooting.SetIsShooting(!this.isFlying);
        }
        else
        {
            this.isFlying = true;
            this.enermyShooting.SetIsShooting(!this.isFlying);
        }
    }
}
