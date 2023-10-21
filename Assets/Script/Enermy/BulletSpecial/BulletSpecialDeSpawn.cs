using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpecialDeSpawn : DeSpawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 5f;
    }

    public override void DeSpawnObj()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
