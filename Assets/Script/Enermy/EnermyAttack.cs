using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAttack : PhongMonobehaviour
{
    [Header("==Boss Attacking==")]
    [SerializeField] protected float attackDelay;
    [SerializeField] protected float attackTime = 0f;
    [SerializeField] protected bool isAttacking = false;

    public virtual void SetIsAttacking(bool value)
    {
        this.isAttacking = value;
    }
}
