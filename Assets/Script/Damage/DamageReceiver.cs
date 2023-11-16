using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : PhongMonobehaviour
{
    //Properties
    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 1;
    [SerializeField] protected bool isDead = false;
    [SerializeField] protected bool isImmortal = false;

    //DamageReceive System
    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        isDead = false;
        this.isImmortal = false;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;
        this.hp += add;
        if(this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct)
    {
        if (this.isImmortal) return;
        if (this.isDead) return;
        this.hp -= deduct;
        if(this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0; 
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();

}
