using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DeSpawnByDis
{
    public override void DeSpawnObj()
    {
        ItemSpawner.Instance.Despawn(transform.parent);
    }
}
