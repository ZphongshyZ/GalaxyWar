using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_1 : ItemReceived
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxReceived = 3;
    }

    protected override void Upgrade()
    {
        if (ShipShooting.Instance.ShootLevel >= this.maxReceived) return;
        ShipShooting.Instance.ShootLevel++;
    }
}
