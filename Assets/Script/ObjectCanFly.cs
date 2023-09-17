using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCanFly : PhongMonobehaviour
{
    [SerializeField] protected float movespeed = 1f;
    [SerializeField] protected Vector3 direction = Vector3.down;

    protected void Update()
    {
        this.Fly();
    }

    protected virtual void Fly()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
