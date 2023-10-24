using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectRecived : PhongMonobehaviour
{
    [SerializeField] protected ObjectCanReceived objectCanReceived;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObj();
    }

    protected virtual void LoadObj()
    {
        this.objectCanReceived = transform.parent.GetComponentInChildren<ObjectCanReceived>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            this.objectCanReceived.AdddObj();
        }
    }
}
