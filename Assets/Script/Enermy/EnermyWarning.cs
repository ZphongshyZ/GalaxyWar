using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyWarning : EnermyAttack
{
    [SerializeField] protected GameObject enermyWarning;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaring();
    }

    protected virtual void LoadWaring()
    {
        this.enermyWarning = GetComponent<EnermyWarning>().gameObject;
    }

    //protected virtual void Warning()
    //{
    //    if (this.isAttacking == false)
    //    {
    //        this.enermyWarning.SetActive(true);
    //        Debug.Log("Meteorite warning");
    //    }
    //    if (this.isAttacking == true)
    //    {
    //        this.enermyWarning.SetActive(false);
    //        Debug.Log("Meteorite stop warning");
    //    }
    //}

    public virtual void Warning()
    {
        this.enermyWarning.SetActive(true);
        Debug.Log("Meteorite warning");
    }

    public virtual void StopWarning()
    {
        this.enermyWarning.SetActive(false);
        Debug.Log("Meteorite stop warning");
    }
}
