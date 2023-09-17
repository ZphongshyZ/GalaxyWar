using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : Spawner
{
    private static EnermySpawner instance;
    public static EnermySpawner Instance { get => instance; }

    public static string enermyName_1 = "Enermy_1";

    [SerializeField] protected float spawnDelay = 7f;
    [SerializeField] protected float spawnTime = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (EnermySpawner.instance != null) Debug.LogError("Only one EnermySpawner allowed to exist");
        EnermySpawner.instance = this;
    }

    private void FixedUpdate()
    {
        this.EnermySpawning();
    }

    protected virtual void EnermySpawning()
    {
        this.spawnTime += Time.fixedDeltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        spawnTime = 0f;
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(enermyName_1);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(EnermySpawner.enermyName_1, pos, rot);
            obj.gameObject.SetActive(true);
        }
    }
}
