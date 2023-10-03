using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyKamikaze : EnermyAttack
{
    [SerializeField] protected float speedKamikaze = 22f;
    
    protected override void Attack()
    {
        base.Attack();
        Invoke(nameof(Kamikaze), 4f);
    }

    protected virtual void Kamikaze()
    {
        if (!isAttacking) return;
        transform.parent.Translate(Vector3.down * this.speedKamikaze * Time.deltaTime);
    }
}
