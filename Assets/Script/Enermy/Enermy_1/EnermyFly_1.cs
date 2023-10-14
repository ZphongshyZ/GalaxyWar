using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyFly_1 : EnermyFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 0.5f;
    }
}
