using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_1 : ObjectCanReceived
{
    [SerializeField] protected ItemDespawn itemDespawn;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxReceived = 3;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDeSpawn();
    }

    protected virtual void LoadDeSpawn()
    {
        this.itemDespawn = transform.parent.GetComponentInChildren<ItemDespawn>();
    }

    public override void Upggrade()
    {
        ShipShooting.Instance.ShootLevel += 1;
    }

    public override bool CanAddObj()
    {
        if(ShipShooting.Instance.ShootLevel >= this.maxReceived) return false;
        return true;
    }

    public override void AdddObj()
    {
        base.AdddObj();
        this.itemDespawn.DeSpawnObj();
    }
}
