using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCanFly : PhongMonobehaviour
{
    [SerializeField] protected bool isFlying = true;
    [SerializeField] protected float movespeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.down;

    protected virtual void Update()
    {
        this.CheckFlying();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }

    protected virtual void Stop()
    {
        this.isFlying = false;
    }

    protected virtual void CheckFlying()
    {
        if (this.isFlying == true) this.Fly();
        else this.Stop();
    }
}