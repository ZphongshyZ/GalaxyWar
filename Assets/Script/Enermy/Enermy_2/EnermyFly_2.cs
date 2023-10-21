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
        this.enermyShooting.Shoot(BulletSpawner.bullet_2, Random.Range(3f, 5f), transform.position, transform.rotation);
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.enermyShooting.IsAttacking = !this.isFlying;
        }
        else
        {
            this.isFlying = true;
            this.enermyShooting.IsAttacking = !this.isFlying;
        }
    }
}
