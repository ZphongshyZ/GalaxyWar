using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletFly : EnermyBulletFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 2.5f;
    }
}
