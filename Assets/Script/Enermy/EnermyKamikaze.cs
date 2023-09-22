using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyKamikaze : EnermyAttack
{
    protected override void Attack()
    {
        base.Attack();
        Invoke(nameof(Kamikaze), 3.5f);
    }

    protected virtual void Kamikaze()
    {
        if (!isAttacking) return;
        transform.parent.Translate(Vector3.down * 22f * Time.deltaTime);
    }
}
