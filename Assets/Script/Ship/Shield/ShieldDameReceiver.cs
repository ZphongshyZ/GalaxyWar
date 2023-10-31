using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDameReceiver : DamageReceiver
{
    protected override void OnDead()
    {
        ShieldOfShip.Instance.IsProtected = false;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.hpMax = 999999999;
    }
}
