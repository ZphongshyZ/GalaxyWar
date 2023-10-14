using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttacking_1 : EnermyAttack
{
    //Shooting
    [Header("==Boss Shooting==")]
    [SerializeField] protected EnermyShooting bossShooting;
    public EnermyShooting BossShooting => bossShooting;

    [SerializeField] protected Transform bossGun;
    [SerializeField] protected Transform target;

    [SerializeField] protected float timeShoot = 7f;
    [SerializeField] protected bool isShooting = false;

    //Kamikaze
    [Header("==Boss ShootGun==")]
    [SerializeField] protected Transform bossShootGun;
    [SerializeField] protected bool isShootGun = false;

    protected string[] attackName = {"Shoot", "ShootGun"};

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeShoot = 0f;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
        this.LoadAttack();
    }

    protected virtual void LoadTarget()
    {
        this.target = GameObject.Find("Ship").transform;
    }

    protected virtual void LoadAttack()
    {
        this.bossGun = GameObject.Find("BossGun").transform;
        this.bossShootGun = GameObject.Find("BossShootGun").transform;
        this.bossShooting = transform.parent.GetComponentInChildren<EnermyShooting>();
    }

    public virtual void Attack()
    {
        if (isShooting == true)
        {
            this.attackTime = 0f;
            this.bossShooting.SetIsAttacking(isShooting);
            this.Shoot();
        }
        if(isShootGun == true)
        {
            this.attackTime = 0f;
            this.bossShooting.SetIsAttacking(isShootGun);
            this.ShootGun();
        }
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = 3f;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        int attack = Random.Range(0, this.attackName.Length);
        if(attack == 0)
        {
            this.isShooting = true;
            this.timeShoot = 7f;
        }
        else if (attack == 1)
        {
            this.isShootGun = true;
            this.timeShoot = 5f;
        }
    }

    protected virtual void Shoot()
    {
        Vector3 diff = this.target.position - bossGun.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        bossGun.rotation = Quaternion.Euler(0, 0, rot_z + 90f);
        Quaternion rot = bossGun.rotation;
        Vector3 pos = bossGun.position;
        pos.x = bossGun.position.x - Random.Range(-0.3f, 0.3f);
        this.bossShooting.Shoot(BulletSpawner.bossBullet, 0.5f, pos, rot);
        timeShoot -= Time.deltaTime;
        if (timeShoot <= 0)
        {
            this.isShooting = false;
            this.bossShooting.SetIsAttacking(isShooting);
        }
    }

    protected virtual void ShootGun()
    {
        Quaternion rot = bossShootGun.rotation;
        Vector3 pos = bossShootGun.position;
        this.bossShooting.ShootGun(BulletSpawner.enermyBullet_2, 0.5f, pos, rot);
        timeShoot -= Time.deltaTime;
        if (timeShoot <= 0)
        {
            this.isShootGun = false;
            this.bossShooting.SetIsAttacking(isShootGun);
        }
    }
}
