using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : PhongMonobehaviour
{
    [SerializeField] protected int dame = 1;

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
