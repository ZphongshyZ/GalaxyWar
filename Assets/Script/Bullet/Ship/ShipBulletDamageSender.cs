using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipBulletDamageSender : BulletDamageSender
{
    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Dangerous"))
        {
            this.SpawnImpactFX(other);
            this.Send(other.transform);
        }
    }

    //Spawn Impact
    protected virtual void SpawnImpactFX(Collider other)
    {
        string fXName = this.GetImpactFX();
        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        hitPos.y -= 0.3f;
        Transform fxImpact = FXSpawner.Instance.Spawn(fXName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impact1;
    }
}
