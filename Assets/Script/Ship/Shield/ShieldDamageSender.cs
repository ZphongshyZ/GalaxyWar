using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageSender : DamageSender
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.dame = 999999999;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Dangerous"))
        {
            this.Send(other.transform);
        }
    }
}
