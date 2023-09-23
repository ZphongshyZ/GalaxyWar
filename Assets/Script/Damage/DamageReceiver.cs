using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : PhongMonobehaviour
{
    [SerializeField] protected EnermySO enermySO;

    [SerializeField] protected int hp = 1;
    [SerializeField] protected int hpMax = 1;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSO();
    }

    protected virtual void LoadSO()
    {
        if (this.enermySO != null) return;
        string resPath = "Enermy/" + transform.parent.name;
        this.enermySO = Resources.Load<EnermySO>(resPath);
        Debug.Log(transform.name + " LoadEnermySO " + resPath, gameObject);
    }

    public virtual void Reborn()
    {
        this.hp = this.hpMax;
        isDead = false;
    }

    public virtual void Add(int add)
    {
        if (this.isDead) return;
        this.hp += add;
        if(this.hp > this.hpMax) this.hp = this.hpMax;
    }

    public virtual void Deduct(int deduct)
    {
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
