using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDeSpawn : DeSpawnByDis
{
    protected override void DeSpawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
