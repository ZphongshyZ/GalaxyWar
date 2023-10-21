using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpecialFly : EnermyFly
{
    //Obj
    [SerializeField] protected Transform right;
    [SerializeField] protected Transform left;

    //Properties
    [SerializeField] protected bool isTargeting;
    [SerializeField] protected int countSpawn = 1;
    [SerializeField] protected float timeSpawn = 0f;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPosObj();
    }

    protected virtual void LoadSpawnPosObj()
    {
        this.right = GameObject.Find("Right").transform;
        this.left = GameObject.Find("Left").transform;
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 3f;
        this.attackDis = -1f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.timeSpawn = 0f;
    }

    protected override void Update()
    {
        base.Update();
        this.Chase();
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis) return;
        this.Target();
    }

    protected virtual void Target()
    {
        this.timeSpawn += Time.deltaTime;
        if (timeSpawn <= 0.35f) return;
        this.timeSpawn = 0f;
        Transform rightBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_3, transform.position, this.right.rotation);
        if (rightBullet == null) return;
        rightBullet.gameObject.SetActive(true);

        Transform leftBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bullet_3, transform.position, this.left.rotation);
        if (leftBullet == null) return;
        leftBullet.gameObject.SetActive(true);
    }
}
