using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemReceived : PhongMonobehaviour
{
    //Components
    [SerializeField] protected ItemDespawn itemDespawn;

    //Properties
    [SerializeField] protected int maxReceived;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
    }

    protected virtual void LoadDespawn()
    {
        this.itemDespawn = transform.parent.GetComponentInChildren<ItemDespawn>();
    }

    protected abstract void Upgrade();

    protected void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.itemDespawn.DeSpawnObj();
            this.Upgrade();
        }    
    }
}
