using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyShooting : PhongMonobehaviour
{
    [SerializeField] protected float shootDelay;
    [SerializeField] protected float shootTime = 0f;
    [SerializeField] protected bool isShooting = false;

    protected void FixedUpdate()
    {
        this.Shoot();
    }

    protected virtual void Shoot()
    {
        shootTime += Time.fixedDeltaTime;
        this.shootDelay = Random.Range(2f, 4f);
        if (this.shootTime < this.shootDelay) return;
        this.shootTime = 0f;
        if (!isShooting) return;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.enermyBullet_2, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    public void SetIsShooting(bool value)
    {
        this.isShooting = value;
    }
}
