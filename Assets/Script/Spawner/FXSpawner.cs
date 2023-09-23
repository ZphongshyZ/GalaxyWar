using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string fxName1 = "Explosion1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Only one FXSpawner allowed to exist");
        FXSpawner.instance = this;
    }
}
