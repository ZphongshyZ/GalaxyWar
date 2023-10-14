using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyKamikaze : EnermyAttack
{   
    public virtual void Kamikaze(float speed, float attackDelay)
    {
        if (!this.isAttacking) this.attackTime = 0;
        this.attackTime += Time.deltaTime;
        this.attackDelay = attackDelay;
        if (this.attackTime < this.attackDelay) return;
        transform.parent.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
