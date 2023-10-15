using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteFly : EnermyFly
{
    //Components
    [SerializeField] protected EnermyWarning enermyWarning;

    //Properties
    [SerializeField] protected bool isTargeting;
    [SerializeField] protected  float time = 0f;
    [SerializeField] protected  float timeDelay = 5f;

    //MeteoriteFly
    protected override void ResetValue()
    {
        base.ResetValue();
        this.movespeed = 4f;
        this.attackDis = 7f;
    }

    protected override void Update()
    {
        base.Update();
        this.Chase();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyWarning();
    }

    protected virtual void LoadEnermyWarning()
    {
        enermyWarning = transform.parent.GetComponentInChildren<EnermyWarning>();
    }

    protected override void Chase()
    {
        if (this.currentDis <= this.attackDis)
        {
            this.isFlying = false;
            this.Target();
            time += Time.deltaTime;
            if (time < timeDelay) return;
            this.Move();
        }
        else
        {
            time = 0f;
            this.isFlying = true;
            this.isTargeting = true;
        }
    }

    protected virtual void Target()
    {
        if(this.isTargeting == true)
        {
            Vector3 newPos = new Vector3(InputManager.Instance.MousePos.x, this.transform.position.y, 0);
            transform.parent.position = Vector3.Lerp(transform.parent.position, newPos, Time.deltaTime * 5f);
            this.enermyWarning.Warning();
        }
    }

    protected virtual void Move()
    {
        this.isTargeting = false;
        transform.parent.Translate(Vector3.down * this.movespeed * Time.deltaTime);
        this.enermyWarning.StopWarning();
    }
}
