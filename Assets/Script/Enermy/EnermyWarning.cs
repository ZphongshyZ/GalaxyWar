using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnermyWarning : PhongMonobehaviour
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

    public virtual void Warning()
    {
        this.enermyWarning.SetActive(true);
    }

    public virtual void StopWarning()
    {
        this.enermyWarning.SetActive(false);
    }
}
