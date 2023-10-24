using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Spawner
{
    private static ItemSpawner instance;
    public static ItemSpawner Instance { get => instance; }

    //Properties
    public static string item_1 = "Item_1";

    protected override void Awake()
    {
        base.Awake();
        if (ItemSpawner.instance != null) Debug.LogError("Only one ItemSpawner allowed to exist");
        ItemSpawner.instance = this;
    }
}
