using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyShooting : EnermyAttack
{
    public virtual void Shoot(string bulletName, Vector3 pos, Quaternion rot)
    {
        if (!isAttacking) return;
        Vector3 spawnPos = pos;
        Quaternion rotation = rot;
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    public virtual void Shoot(string bulletName, float shootDelay, Vector3 pos, Quaternion rot)
    {
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = shootDelay;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        this.Shoot(bulletName, pos, rot);
    }

    public virtual void ShootGun(string bulletName, float shootDelay, Vector3 pos, Quaternion rot, float bulletSpread, int bulletCount)
    {
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = shootDelay;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        Vector3 spawnPos = pos;
        Quaternion rotation = Quaternion.Euler(0f, 0f, bulletSpread);
        float Spread = bulletSpread;
        for (int i = 0; i < bulletCount; i++)
        {
            spawnPos.x -= 0.01f;
            bulletSpread -= (Spread / 5 );
            rotation = Quaternion.Euler(0f, 0f, bulletSpread);
            Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
        }
    }
}
