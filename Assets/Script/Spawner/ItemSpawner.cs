using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    //Singleton
    private static ItemSpawner instance;
    public static ItemSpawner Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("Only one ItemSpawner allowed to exist");
        ItemSpawner.instance = this;
    }

    //ItemSpawner
    public virtual void DropItem(List<ItemDropRate> dropItem, Vector3 pos, Quaternion rot)
    {
        int itemNum = this.GachaItem(dropItem);
        ItemCode itemCode = dropItem[itemNum].itemSO.itemCode;
        Transform itemDrop = this.Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }


    public virtual int GachaItem(List<ItemDropRate> dropList)
    {
        int item = 0;
        int rate = Random.Range(0, 100);
        for (int i = 0; i < dropList.Count; i++)
        {
            if (rate <= dropList[i].dropRate)
            {
                item = i;
            }
        }
        return item;
    }
}
