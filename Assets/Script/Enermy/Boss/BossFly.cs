using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFly : EnermyFly
{
    //Components
    [SerializeField] protected BossAttacking_1 bossAttacking;
    [SerializeField] protected BossDamageReceiver bossHealth;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAttack();
        this.LoadHealth();
    }

    protected virtual void LoadAttack()
    {
        this.bossAttacking = transform.parent.GetComponentInChildren<BossAttacking_1>();
    }

    protected virtual void LoadHealth()
    {
        this.bossHealth = transform.parent.GetComponentInChildren<BossDamageReceiver>();
    }

    //BossFly
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
        this.bossAttacking.IsAttacking = !this.isFlying;
        this.bossHealth.IsImortal = this.isFlying;
        this.bossHealth.BossHealthBar.gameObject.SetActive(!this.isFlying);
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
        }
        else
        {
            this.isFlying = true;
        }
    }
}
