using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_3 : EnermyFly
{
    //Components
    [SerializeField] protected EnermyKamikaze enermyKamikaze;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyKamikaze();
    }

    protected virtual void LoadEnermyKamikaze()
    {
        this.enermyKamikaze = transform.parent.GetComponentInChildren<EnermyKamikaze>();
    }

    //EnermyFly
    protected override void Update()
    {
        base.Update();
        this.Chase();
        this.enermyKamikaze.Kamikaze(22f, 4f);
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.enermyKamikaze.IsAttacking = !this.isFlying;
        }
        else
        {
            this.isFlying = true;
            this.enermyKamikaze.IsAttacking = !this.isFlying;
            this.ResetValue();
        }
    }
}
