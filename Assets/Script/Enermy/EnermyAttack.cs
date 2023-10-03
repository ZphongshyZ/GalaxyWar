using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAttack : PhongMonobehaviour
{
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackTime = 0f;
    [SerializeField] protected bool isAttacking = false;

    protected virtual void FixedUpdate()
    {
        
    }

    protected virtual void Update()
    {
        this.Attack();
    }

    protected virtual void Attack()
    {
        //For Override
    }

    public virtual void SetIsAttacking(bool value)
    {
        this.isAttacking = value;
    }
}
