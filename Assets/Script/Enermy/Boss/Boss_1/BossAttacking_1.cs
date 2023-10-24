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

    [SerializeField] protected float timeShoot;
    [SerializeField] protected bool isShooting = false;

    //ShootGun
    [Header("==Boss ShootGun==")]
    [SerializeField] protected Transform bossShootGun;
    [SerializeField] protected bool isShootGun = false;

    //ShotSpecial
    [Header("==Shoot Special==")]
    [SerializeField] protected bool isShootSpecial = false;
    [SerializeField] protected int shootCount;

    //Properties
    protected string[] attackName = { "Shoot", "ShootGun", "ShotSpecial" };

    //LoadComponents
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


    //Boss Atatck
    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeShoot = 0f;
    }

    public virtual void Attack()
    {
        if (this.isShooting == true)
        {
            this.attackTime = 0f;
            this.bossShooting.IsAttacking = this.isShooting;
            this.Shoot();
        }
        if (this.isShootGun == true)
        {
            this.attackTime = 0f;
            this.bossShooting.IsAttacking = this.isShootGun;
            this.ShootGun();
        }
        if (this.isShootSpecial == true)
        {
            this.attackTime = 0;
            this.bossShooting.IsAttacking = this.isShootSpecial;
            this.ShootSpecial();
        }
        if (!isAttacking) return;
        this.attackTime += Time.deltaTime;
        this.attackDelay = 3f;
        if (this.attackTime < this.attackDelay) return;
        this.attackTime = 0f;
        int attack = Random.Range(0, this.attackName.Length);
        Debug.Log(attackName[attack]);
        if (this.attackName[attack] == "Shoot")
        {
            this.isShooting = true;
            this.timeShoot = 7f;
        }
        else if (this.attackName[attack] == "ShootGun")
        {
            this.isShootGun = true;
            this.timeShoot = 5f;
        }
        else if (this.attackName[attack] == "ShotSpecial")
        {
            this.isShootSpecial = true;
            this.shootCount = 1;
        }
    }

    //Shoot
    protected virtual void Shoot()
    {
        if (this.target == null) return;
        Vector3 diff = this.target.position - this.bossGun.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        this.bossGun.rotation = Quaternion.Euler(0, 0, rot_z + 90f);
        Quaternion rot = this.bossGun.rotation;
        Vector3 pos = this.bossGun.position;
        pos.x = this.bossGun.position.x - Random.Range(-0.3f, 0.3f);
        this.bossShooting.Shoot(BulletSpawner.bullet_3, 0.5f, pos, rot);
        this.timeShoot -= Time.deltaTime;
        if (this.timeShoot <= 0)
        {
            this.isShooting = false;
            this.bossShooting.IsAttacking = this.isShooting;

        }
    }

    //ShootGun
    protected virtual void ShootGun()
    {
        Quaternion rot = bossShootGun.rotation;
        Vector3 pos = bossShootGun.position;
        this.bossShooting.ShootGun(BulletSpawner.bullet_2, 0.5f, pos, rot, 60f, 9);
        timeShoot -= Time.deltaTime;
        if (timeShoot <= 0)
        {
            this.isShootGun = false;
            this.bossShooting.IsAttacking = this.isShootGun;
        }
    }

    //ShootSpecial
    protected virtual void ShootSpecial()
    {
        Quaternion rot = this.bossShootGun.rotation;
        Vector3 pos = this.bossShootGun.position;
        this.bossShooting.Shoot("Bullet_4", pos, rot);
        this.shootCount--;
        if (this.shootCount <= 0)
        {
            this.isShootSpecial = false;
            this.bossShooting.IsAttacking = this.isShootSpecial;
        }
    }
}
