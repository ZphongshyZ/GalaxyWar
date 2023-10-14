using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyShooting : EnermyAttack
{
    public virtual void Shoot(string bulletName, float shootDelay)
    {
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        this.Shoot(bulletName, shootDelay, spawnPos, rotation);
    }

    public virtual void Shoot(string bulletName, float shootDelay, Vector3 pos, Quaternion rot)
    {
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = shootDelay;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        Vector3 spawnPos = pos;
        Quaternion rotation = rot;
        Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    public virtual void ShootGun(string bulletName, float shootDelay, Vector3 pos, Quaternion rot)
    {
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = shootDelay;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        Vector3 spawnPos = pos;
        spawnPos.x = pos.x - 0.1f;
        Quaternion rotation = rot;
        rotation.z = rot.z - 1f;
        for(int i = 0; i < 10; i++)
        {
            spawnPos.x += 0.01f;
            rotation.z += 0.1f;
            Transform newBullet = BulletSpawner.Instance.Spawn(bulletName, spawnPos, rotation);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
        }
    }
}
