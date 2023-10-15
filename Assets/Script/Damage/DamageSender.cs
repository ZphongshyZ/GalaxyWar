using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : PhongMonobehaviour
{
    //Properties
    [SerializeField] protected int dame = 1;

    //DamageSender System
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.dame);
    }
}
