using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : EnermyFly
{
    [SerializeField] protected BossAttacking_1 bossAttacking;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttack();
    }

    protected virtual void LoadAttack()
    {
        this.bossAttacking = transform.parent.GetComponentInChildren<BossAttacking_1>();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.attackDis = 5.5f;
    }

    protected override void Update()
    {
        base.Update();
        this.Chase();
        this.bossAttacking.Attack();
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.bossAttacking.SetIsAttacking(!isFlying);
        }
        else
        {
            this.isFlying = true;
            this.bossAttacking.SetIsAttacking(!isFlying);
        }
    }
}
