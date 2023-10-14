using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyFly_4 : EnermyFly
{
    private float startingYPos;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.direction = Vector3.right;
        this.movespeed = 1.5f;
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.startingYPos = transform.position.y;
    }

    protected override void Fly()
    {
        float xPos = transform.parent.position.x;
        float yPos = this.startingYPos + Mathf.Sin((Time.time * this.frequency) + this.phase) * this.amplitude;
        float zPos = transform.parent.position.z;

        transform.parent.position = new Vector3(xPos, yPos, zPos);
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
