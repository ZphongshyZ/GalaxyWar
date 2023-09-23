using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyBulletFly : BulletFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 5f;
        this.direction = Vector3.down;
    }
}
