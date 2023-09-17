using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipBulletDamageSender : BulletDamageSender
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dangerous"))
        {
            this.Send(other.transform);
        }
    }
}
