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
        this.enermyDeSpawn.DeSpawnObj();
    }
}
