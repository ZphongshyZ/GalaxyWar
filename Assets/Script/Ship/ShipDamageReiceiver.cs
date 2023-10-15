using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReiceiver : DamageReceiver
{
    [SerializeField] protected DeSpawnByDis playerDespawn;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerDeSpawn();
    }

    protected virtual void LoadPlayerDeSpawn()
    {
        this.playerDespawn = transform.parent.GetComponentInChildren<DeSpawnByDis>();
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.playerDespawn.DeSpawnObj();
        GameOverScene.Instance.IsLossing = true;
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        if (transform.parent.name == "Enermy_3") return FXSpawner.explosion2;
        else if (transform.parent.name == "Boss_1") return FXSpawner.explosion3;
        return FXSpawner.explosion1;
    }

    public override void Reborn()
    {
        this.hpMax = this.enermySO.hpMax;
        base.Reborn();
    }
}
