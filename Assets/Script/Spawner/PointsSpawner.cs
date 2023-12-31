using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsSpawner : Spawner
{
    //Singleton
    private static PointsSpawner instance;
    public static PointsSpawner Instance { get => instance; }

    //Properties
    public static string coin_1 = "Coin_1";
    public static string dinamond_1 = "Dinamond_1";
    public static string dinamond_2 = "Dinamond_2";
    public static string dinamond_3 = "Dinamond_3";

    protected override void Awake()
    {
        base.Awake();
        if (PointsSpawner.instance != null) Debug.LogError("Only one PointsSpawner allowed to exist");
        PointsSpawner.instance = this;
    }

    //PointSpawner System
    public virtual void DropPoint(List<PointDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        int pointNum = GachaPoint(dropList);
        PointsCode pointCode = dropList[pointNum].pointSO.pointsCode;
        Transform pointDrop = this.Spawn(pointCode.ToString(), pos, rot);
        if (pointDrop == null) return;
        pointDrop.gameObject.SetActive(true);
    }

    public virtual int GachaPoint(List<PointDropRate> dropList)
    {
        int item = 0;
        int rate = Random.Range(0, 100);
        for (int i = 0; i < dropList.Count; i++)
        {
            if(rate <= dropList[i].dropRate)
            {
                item = i;
            }
        }
        return item;
    }
}
