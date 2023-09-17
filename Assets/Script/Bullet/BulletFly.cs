using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : ObjectCanFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 15f;
    }
}
