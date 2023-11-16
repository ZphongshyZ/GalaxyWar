using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipDamageReiceiver : DamageReceiver
{
    //Components
    [SerializeField] protected DeSpawnByDis playerDespawn;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerDeSpawn();
    }

    protected virtual void LoadPlayerDeSpawn()
    {
        this.playerDespawn = transform.parent.GetComponentInChildren<DeSpawnByDis>();
    }

    //ShipDamageReceiver
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.playerDespawn.DeSpawnObj();
        GameOverScene.Instance.IsLossing = true;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.hpMax = 1;
    }

    protected virtual void Update()
    {
        this.isImmortal = ShieldOfShip.Instance.IsProtected;
    }

}
