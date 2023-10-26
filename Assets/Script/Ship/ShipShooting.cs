using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ShipShooting : PhongMonobehaviour
{
    //Singleton
    protected static ShipShooting instance;
    public static ShipShooting Instance { get => instance; }

    //Properties
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.05f;
    [SerializeField] protected float shootTime = 0f;
    [SerializeField] protected int shootLevel = 1;
    public int ShootLevel { get => shootLevel; set => shootLevel = value; }

    protected override void Awake()
    {
        base.Awake();
        if (ShipShooting.instance != null) Debug.Log("Only 1 ShipShooting allowed to exist");
        ShipShooting.instance = this;
    }

    //ShipShooting
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
        float distanceBetweenBullet = 0.18f;
        float extremeLeft = distanceBetweenBullet;
        if (ShipShooting.Instance.shootLevel <= 1)
        {
            Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_1, spawnPos, rotation);
            if (newBullet == null) return;
            newBullet.gameObject.SetActive(true);
        }
        else
        {
            if (this.shootLevel >= 2) extremeLeft = extremeLeft * (this.shootLevel / 2);
            spawnPos.x = spawnPos.x - extremeLeft;
            for(int i = 0; i < this.shootLevel; i++)
            {
                Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_1, spawnPos, rotation);
                if (newBullet == null) return;
                newBullet.gameObject.SetActive(true);
                if (this.shootLevel % 2 == 0 && i == (this.shootLevel/2 -1)) spawnPos.x += distanceBetweenBullet * 2;
                else spawnPos.x += distanceBetweenBullet;
            }
        }
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnFiring == 1;
        return this.isShooting;
    }
}
