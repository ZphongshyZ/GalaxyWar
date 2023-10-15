using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : Spawner
{
    private static EnermySpawner instance;
    public static EnermySpawner Instance { get => instance; }

    public static string[] enermyNames = new string[] { "Enermy_1", "Enermy_2", "Enermy_3", "Meteorite",  "Enermy_4", "Enermy_5", "Enermy_4.5", "Enermy_5.5"};

    public static string[] bossNames = new string[] { "Boss_1", "Boss_1" };

    public static List<string> enermyLevel = new List<string>();

    [SerializeField] protected float spawnDelay = 7.5f;
    [SerializeField] protected float spawnDelayMin = 4f;
    [SerializeField] protected float spawnTime = 0f;
    [SerializeField] public int bossCount = 0;
    [SerializeField] public int level = 0;
    [SerializeField] protected int count = 0;
    [SerializeField] protected int nextCount = 5;

    protected override void Start()
    {
        base.Start();
        EnermySpawner.enermyLevel.Add(enermyNames[0]);
    }

    protected override void Awake()
    {
        base.Awake();
        if (EnermySpawner.instance != null) Debug.LogError("Only one EnermySpawner allowed to exist");
        EnermySpawner.instance = this;
        EnermySpawner.enermyLevel.Clear();
        this.level = 0;
        this.count = 0;
        this.nextCount = 5;
        this.spawnDelay = 7.5f;
    }

    private void Update()
    {
        this.SpawnGame();
        this.SetLevel();
    }


    protected virtual void SetLevel()
    {
        if (this.count == this.nextCount)
        {
            if (this.level +1 >= EnermySpawner.enermyNames.Length)
            {
                this.level++;
                Debug.Log("Level: " + this.level);
                this.nextCount += 1;
                this.count = 0;
                this.spawnDelay -= 0.5f;
                if (this.spawnDelay <= this.spawnDelayMin) this.spawnDelay = this.spawnDelayMin;
            }
            else
            {
                this.level++;
                EnermySpawner.enermyLevel.Add(enermyNames[this.level]);
                Debug.Log("Add Enermy: " + EnermySpawner.enermyNames[this.level]);
                this.count = 0;
                this.spawnDelay -= 0.8f;
                this.nextCount += 1;
                Debug.Log("Level: " + this.level);
                if (this.spawnDelay <= this.spawnDelayMin) this.spawnDelay = this.spawnDelayMin;
            }
        }
    }

    protected virtual void SpawnGame()
    {
        if (WinScene.Instance.IsWinning == true || LoseScene.Instance.IsLossing == true) return;
        if(this.level > 0 && this.level % 8 == 0) this.BossSpawning();
        this.EnermySpawning();

    }

    protected virtual void EnermySpawning()
    {
        if (this.bossCount > 0) return;
        this.spawnTime += Time.deltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0f;
        string name = RandomEnermy(EnermySpawner.enermyLevel);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(name, pos, rot);
            obj.gameObject.SetActive(true);
        }
        this.count++;
    }
    
    protected virtual void BossSpawning()
    {
        if (this.bossCount > 0) return;
        this.spawnTime += Time.deltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0f;
        string name = RandomEnermy(EnermySpawner.bossNames);
        List<Transform> enermys = SpawnPoint.Instance.ListEnermy(name);
        for (int i = 0; i < enermys.Count; i++)
        {
            Transform ranPos = enermys[i];
            Vector3 pos = ranPos.position;
            Quaternion rot = transform.rotation;
            Transform obj = this.Spawn(name, pos, rot);
            obj.gameObject.SetActive(true);
        }
        this.bossCount++;
    }

    protected virtual string RandomEnermy(string[] enermys)
    {
        int rand = Random.Range(0, enermys.Length);
        return enermys[rand];
    }

    protected virtual string RandomEnermy(List<string> enermys)
    {
        int rand = Random.Range(0, enermys.Count);
        return enermys[rand];
    }
}
