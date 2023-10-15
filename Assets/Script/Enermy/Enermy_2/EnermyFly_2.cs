using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_2 : EnermyFly
{
    //Components
    [SerializeField] protected EnermyShooting enermyShooting;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyShooting();
    }

    protected virtual void LoadEnermyShooting()
    {
        this.enermyShooting = transform.parent.GetComponentInChildren<EnermyShooting>();
    }

    //EnermyFly
    protected override void Update()
    {
        base.Update();
        this.Chase();
        this.enermyShooting.Shoot(BulletSpawner.enermyBullet_2, Random.Range(3f, 5f));
    }

    protected override void Chase()
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
