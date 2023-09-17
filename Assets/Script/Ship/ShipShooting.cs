using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : PhongMonobehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.1f;
    [SerializeField] protected float shootTime = 0f;

    private void Update()
    {
        this.IsShooting();   
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTime += Time.deltaTime;
        if (this.shootTime < this.shootDelay) return;
        this.shootTime = 0f;
        if (!this.isShooting) return;
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        rotation.z = 180f;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.shipBullet, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
