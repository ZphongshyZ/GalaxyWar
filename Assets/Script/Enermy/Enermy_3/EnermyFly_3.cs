using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_3 : EnermyFly
{
    [SerializeField] protected EnermyKamikaze enermyKamikaze;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyKamikaze();
    }

    protected virtual void LoadEnermyKamikaze()
    {
        this.enermyKamikaze = transform.parent.GetComponentInChildren<EnermyKamikaze>();
    }

    protected override void Update()
    {
        base.Update();
        this.Chase();
    }

    protected virtual void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.enermyKamikaze.SetIsAttacking(!this.isFlying);
        }
        else
        {
            this.isFlying = true;
            this.enermyKamikaze.SetIsAttacking(!this.isFlying);
            this.ResetValue();
        }
    }
}
