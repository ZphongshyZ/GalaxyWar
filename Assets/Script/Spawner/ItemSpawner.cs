using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ItemSpawner : Spawner
{
    private static ItemSpawner instance;
    public static ItemSpawner Instance { get => instance; }

    //Properties
    public string[] items = { "Item_1" };

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("Only one ItemSpawner allowed to exist");
        ItemSpawner.instance = this;
    }

    public virtual void DropItem(Vector3 pos, Quaternion rot)
    {
        string item = this.GachaItem(this.items);
        Transform pointDrop = this.Spawn(item, pos, rot);
        if (pointDrop == null) return;
        pointDrop.gameObject.SetActive(true);
    }

    protected virtual string GachaItem(string[] items)
    {
        int rate = Random.Range(0, items.Length);      
        return items[rate];
    }
}
