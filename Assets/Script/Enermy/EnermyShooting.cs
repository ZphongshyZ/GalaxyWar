using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyShooting : EnermyAttack
{
    protected override void Attack()
    {
        base.Attack();
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        attackTime += Time.fixedDeltaTime;
        this.attackDelay = Random.Range(2f, 4f);
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        if (!isAttacking) return;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.enermyBullet_2, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }
}
