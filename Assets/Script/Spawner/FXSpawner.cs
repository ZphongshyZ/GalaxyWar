using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance { get => instance; }

    public static string explosion1 = "Explosion1";
    public static string explosion2 = "Explosion2";
    public static string explosion3 = "Explosion3";
    public static string impact1 = "Impact1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null) Debug.LogError("Only one FXSpawner allowed to exist");
        FXSpawner.instance = this;
    }
}
