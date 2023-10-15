using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletDeSpawn bulletDeSpawn;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDeSpawn();
    }

    protected virtual void LoadBulletDeSpawn()
    {
        bulletDeSpawn = transform.parent.GetComponentInChildren<BulletDeSpawn>();
    }

    //Send Damage
    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletDeSpawn.DeSpawnObj();
    }
}
