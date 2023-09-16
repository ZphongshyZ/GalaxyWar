using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFly : MonoBehaviour
{
    [SerializeField] protected float movespeed = 15f;
    [SerializeField] Vector3 direction = Vector3.down;

    private void Update()
    {
        transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
    }
}
