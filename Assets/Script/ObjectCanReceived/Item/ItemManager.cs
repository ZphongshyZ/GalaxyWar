using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : PhongMonobehaviour
{
    //Singleton
    protected static ItemManager instance;
    public static ItemManager Instance { get => instance; }

    protected override void Awake()
    {
        base.Awake();
        if (ItemManager.instance != null) Debug.Log("Only 1 ItemManager allowed to exist");
        ItemManager.instance = this;
    }
}
