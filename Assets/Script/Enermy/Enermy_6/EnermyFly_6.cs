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
    }

    protected override void Fly()
    {
        Vector3 direction1 = Vector3.right;
        Vector3 direction2 = Vector3.down;
        this.direction = direction1 + direction2;
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
