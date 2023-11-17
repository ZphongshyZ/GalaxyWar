using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDamageReceiver : EnermyDamageReceiver
{
    [SerializeField] protected HealthBar bossHealthBar;
    public HealthBar BossHealthBar { get => bossHealthBar; set => bossHealthBar = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        bossHealthBar = transform.parent.GetComponentInChildren<HealthBar>();
    }

    protected override void Start()
    {
        bossHealthBar.UpdateHealthBar(this.hpMax, this.hp);
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        bossHealthBar.UpdateHealthBar(this.hpMax, this.hp);
    }
}
