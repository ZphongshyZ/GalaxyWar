using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDeSpawn : DeSpawnByDis
{
    public override void DeSpawnObj()
    {
        EnermySpawner.Instance.Despawn(transform.parent);
        if(transform.parent.name == "Boss_1")
        {
            EnermySpawner.Instance.bossCount--;
            EnermySpawner.Instance.level++;
        }
    }
}
