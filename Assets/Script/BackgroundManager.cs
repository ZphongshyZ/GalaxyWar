using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundManager : PhongMonobehaviour
{
    [SerializeField] protected Transform zone;

    [SerializeField] protected float movespeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.down;

    [SerializeField] protected float currentDis;
    [SerializeField] protected float limitDis = 25f;
    [SerializeField] protected float reSpawnDis = 40.96f*2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadData();
    }

    protected virtual void LoadData()
    {
        this.zone = GameObject.Find("Zone").transform;
    }

    protected void Update()
    {
        this.Run();
        this.GetParallaxEffect();
        this.GetDistance();
    }


    protected virtual void Run()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }

    protected virtual void GetDistance()
    {
        this.currentDis = this.zone.transform.position.y - transform.position.y;
    }

    protected virtual void GetParallaxEffect()
    {
        if (this.currentDis < this.limitDis) return;
        Debug.Log("Spawning");
        Vector3 pos = transform.position;
        pos.y += this.reSpawnDis;
        transform.position = pos;
    }
}
