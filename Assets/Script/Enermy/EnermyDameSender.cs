using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDameSender : DamageSender
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.Send(other.transform);
        }
    }
}
