using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDespawn : DeSpawnByDis
{
    public override void DeSpawnObj()
    {
        PointsSpawner.Instance.Despawn(transform.parent);
    }
}
