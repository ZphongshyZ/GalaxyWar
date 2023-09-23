using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXDeSpawn : DeSpawnByTime
{
    public override void DeSpawnObj()
    {
        FXSpawner.Instance.Despawn(transform.parent);
    }
}
