using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFly : ObjectCanFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 1f;
    }
}
