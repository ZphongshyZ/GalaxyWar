using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : Spawner
{
    private static EnermySpawner instance;
    public static EnermySpawner Instance { get => instance; }

    public static string[] enermyNames = new string[] { /*"Enermy_1", "Enermy_2", "Enermy_3",*/ "Meteorite" };

    [SerializeField] protected float spawnDelay = 7f;
    [SerializeField] protected float spawnTime = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (EnermySpawner.instance != null) Debug.LogError("Only one EnermySpawner allowed to exist");
        EnermySpawner.instance = this;
    }

    private void Update()
    {
        this.EnermySpawning();
    }

    protected virtual void EnermySpawning()
    {
        this.spawnTime += Time.deltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        spawnTime = 0f;
        string name = RandomEnermy(EnermySpawner.enermyNames);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(name, pos, rot);
            obj.gameObject.SetActive(true);
        }
    }

    protected virtual string RandomEnermy(string[] enermys)
    {
        int rand = Random.Range(0, enermys.Length);
        return enermys[rand];
    }
}
