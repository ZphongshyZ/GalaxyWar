using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointReceived : PhongMonobehaviour
{
    [SerializeField] protected  PointDespawn coinDespawn;
    [SerializeField] protected PointSO pointSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCoinDespawn();
        this.LoadSO();
    }

    protected virtual void LoadSO()
    {
        if (this.pointSO != null) return;
        string resPath = "Point/" + transform.parent.name;
        this.pointSO = Resources.Load<PointSO>(resPath);
        Debug.Log(transform.name + " LoadPointSO " + resPath, gameObject);
    }

    protected virtual void LoadCoinDespawn()
    {
        coinDespawn = transform.parent.GetComponentInChildren<PointDespawn>();
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            this.coinDespawn.DeSpawnObj();
        }
    }
}
