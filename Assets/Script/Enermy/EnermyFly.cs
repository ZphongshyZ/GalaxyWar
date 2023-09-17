using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyFly : ObjectCanFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 1f;
        this.direction = Vector3.down;
    }
}
