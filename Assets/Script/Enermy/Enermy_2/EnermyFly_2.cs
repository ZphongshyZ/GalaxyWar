using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_2 : EnermyFly
{
    [SerializeField] protected EnermyShooting enermyShooting;

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
            this.enermyShooting.SetIsAttacking(!this.isFlying);
        }
        else
        {
            this.isFlying = true;
            this.enermyShooting.SetIsAttacking(!this.isFlying);
        }
    }
}
