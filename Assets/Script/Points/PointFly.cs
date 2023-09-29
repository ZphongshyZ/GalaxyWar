using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointFly : ObjectCanFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 5f;
    }
}
