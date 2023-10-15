using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyWarning : PhongMonobehaviour
{
    //GameObj
    [SerializeField] protected GameObject enermyWarning;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWaring();
    }

    protected virtual void LoadWaring()
    {
        this.enermyWarning = GetComponent<EnermyWarning>().gameObject;
    }

    //EnermyWarning
    public virtual void Warning()
    {
        this.enermyWarning.SetActive(true);
    }

    public virtual void StopWarning()
    {
        this.enermyWarning.SetActive(false);
    }
}
