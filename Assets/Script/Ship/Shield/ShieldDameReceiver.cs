using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDameReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        ShieldOfShip.Instance.IsProtected = false;
    }

    public override void Reborn()
    {
        base.Reborn();
        this.isImmortal = true;
    }
}
