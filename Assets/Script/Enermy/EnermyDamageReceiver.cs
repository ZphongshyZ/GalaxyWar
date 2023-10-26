using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyDamageReceiver : DamageReceiver
{
    [SerializeField] protected EnermySO enermySO;

    //Properties
    [SerializeField] protected EnermyDeSpawn enermyDeSpawn;

    //LoadComponents
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnermyDeSpawn();
        this.LoadSO();
    }

    protected virtual void LoadEnermyDeSpawn()
    {
        enermyDeSpawn = transform.parent.GetComponentInChildren<EnermyDeSpawn>();
    }

    protected virtual void LoadSO()
    {
        if (this.enermySO != null) return;
        string resPath = "Enermy/" + transform.parent.name;
        this.enermySO = Resources.Load<EnermySO>(resPath);
        Debug.Log(transform.name + " LoadEnermySO " + resPath, gameObject);
    }


    //EnermyDamageReceiver System
    protected override void OnDead()
    {
        this.OnDeadFX();
        this.enermyDeSpawn.DeSpawnObj();

        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        PointsSpawner.Instance.Drop( this.enermySO.pointDropList ,dropPos, dropRot);
        ItemSpawner.Instance.DropItem(this.enermySO.itemDropList, dropPos, dropRot);
    }

    public override void Reborn()
    {
        this.hpMax = this.enermySO.hpMax;
        base.Reborn();
    }

    //Impact
    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXName()
    {
        if (transform.parent.name == "Enermy_3") return FXSpawner.explosion2;
        else if (transform.parent.name == "Boss_1") return FXSpawner.explosion3;
        return FXSpawner.explosion1;
    }
}
