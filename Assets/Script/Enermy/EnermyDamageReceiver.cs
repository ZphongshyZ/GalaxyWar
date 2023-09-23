using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnermyDeSpawn enermyDeSpawn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyDeSpawn();
    }

    protected virtual void LoadEnermyDeSpawn()
    {
        enermyDeSpawn = transform.parent.GetComponentInChildren<EnermyDeSpawn>();
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.enermyDeSpawn.DeSpawnObj();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.fxName1;
    }

    public override void Reborn()
    {
        this.hpMax = this.enermySO.hpMax;
        base.Reborn();
    }
}
