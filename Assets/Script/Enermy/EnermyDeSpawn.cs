using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDeSpawn : DeSpawnByDis
{
    public override void DeSpawnObj()
    {
        EnermySpawner.Instance.Despawn(transform.parent);
    }
}
