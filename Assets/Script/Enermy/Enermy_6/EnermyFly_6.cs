using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnermyFly_6 : EnermyFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 0.5f;
        this.direction = Vector3.right + Vector3.down;
    }
}
