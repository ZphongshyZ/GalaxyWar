using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.3f;

    private void FixedUpdate()
    {
        this.GetTargetPos();
        this.Move();
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }

    protected virtual void Move()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPos, this.speed);
        transform.parent.position = newPos;
    }
}
